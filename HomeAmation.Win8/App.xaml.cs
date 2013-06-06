using Callisto.Controls;
using Callisto.Controls.SettingsManagement;
using GalaSoft.MvvmLight.Threading;
using HomeAmation.Controls;
using HomeAmation.Pcl.Model;
using HomeAmation.Win8;
using System;
using System.Diagnostics;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Networking.Connectivity;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace HomeAmation
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        public static string SummaryDataUrl = "http://homeamation.azurewebsites.net/api/SummaryTemperatureData";
        public static string HistoricalDataUrl = "http://homeamation.azurewebsites.net/api/HistoricalTemperatureData";
        //public static string SummaryDataUrl = "http://jeffa.jeffa.org:81/ha/SummaryData.php";
        // public static string HistoricalDataUrl = "http://jeffa.jeffa.org:81/homeautomation/HistoricalData.php";

        public static bool registeredNetworkStatusNotif = false; 
        NetworkStatusChangedEventHandler networkStatusCallback;

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            InitializeComponent();
            Suspending += OnSuspending;
            InitializeNetworkChanged();     // track internet network connectivity 
        }

        public async void InitializeNetworkChanged()
        {
            Debug.WriteLine("testing this: {0}", this.ToString());
            Utility.Log(this, "InitializeNetworkChanged");
            try
            {
                networkStatusCallback = new NetworkStatusChangedEventHandler(OnNetworkStatusChange);
                if (!registeredNetworkStatusNotif)
                {
                    NetworkInformation.NetworkStatusChanged += networkStatusCallback;
                    registeredNetworkStatusNotif = true; // TODO seems inelagent... Can't I test if it is registered rather than using this boolean flag? 
                }

                OnNetworkStatusChange(null); // set initial state of internet connectivity 

                //if (internetProfileInfo == "")
                //{
                //    //rootPage.NotifyUser("No network status change. ", NotifyType.StatusMessage);
                //    // RwAppSettings.IsDoSkyDriveBackup = ????????????????????????????????????????????????????????????????????
                //}
                //else
                //{
                //    // rootPage.NotifyUser(internetProfileInfo, NotifyType.StatusMessage);
                //}
            }
            catch (Exception ex)
            {
                // rootPage.NotifyUser("Unexpected exception occurred: " + ex.ToString(), NotifyType.ErrorMessage);
                Debug.WriteLine("networkStatusCallback caught exception: {0}", ex);
            }
        }

        private async void OnNetworkStatusChange(object sender)
        {
            try
            {
                // get the ConnectionProfile that is currently used to connect to the Internet                
                ConnectionProfile internetConnectionProfile = NetworkInformation.GetInternetConnectionProfile();

                if (internetConnectionProfile != null && internetConnectionProfile.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess)
                {
                    HasInternetConnectivity = true;
                    Utility.Log(this, "HasInternetConnectivity true"); // TODO can I register my Utility.Log to only compile and run on debug without a #ifdef like Debug.Writeline ? 
                    Debug.WriteLine("OnNetworkStatusChange {0}", App.HasInternetConnectivity);
                }
                else
                {
                    HasInternetConnectivity = false;
                    Debug.WriteLine("OnNetworkStatusChange {0}", App.HasInternetConnectivity);
                }
                // internetProfileInfo = "";
            }
            catch (Exception ex)
            {
                Debug.WriteLine("OnNetworkStatusChange caught exception", ex);
            }
        }

        public static bool HasInternetConnectivity { get; set; } // TODO would the method below be better to use in that it might be more responsive? 
        // that is this bool has to be set by a network changed event where the method interrogates the internet connection profile whenever interrogated? 

        public static bool isConnectedToInternet()
        {
            ConnectionProfile profile = NetworkInformation.GetInternetConnectionProfile();
            return (profile != null && profile.GetNetworkConnectivityLevel().Equals(NetworkConnectivityLevel.InternetAccess));
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used when the application is launched to open a specific file, to display
        /// search results, and so forth.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            AppSettings.Current.AddCommand<GeneralSettings>("General", SettingsFlyout.SettingsFlyoutWidth.Wide);

            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                if (args.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                if (!rootFrame.Navigate(typeof(MainPage), args.Arguments))
                {
                    throw new Exception("Failed to create initial page");
                }
            }
            // Ensure the current window is active
            Window.Current.Activate();

            DispatcherHelper.Initialize();
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }
    }
}
