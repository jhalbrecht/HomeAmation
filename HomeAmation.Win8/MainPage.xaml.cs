using System;
using HomeAmation.Pcl.ViewModel;
using Windows.System;
using Windows.UI.ApplicationSettings;
using Windows.UI.Xaml.Navigation;

// TODO is there a way to remove a TextBlock and it's animation key frames using a design tool? 

namespace HomeAmation.Win8
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            SettingsPane.GetForCurrentView().CommandsRequested += MainPage_CommandsRequested;
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets the view's ViewModel.
        /// </summary>
        public MainViewModel Vm
        {
            get
            {
                return (MainViewModel)DataContext;
            }
        }

        private void MainPage_CommandsRequested(SettingsPane sender, SettingsPaneCommandsRequestedEventArgs args)
        {
            args.Request.ApplicationCommands.Add(new
                SettingsCommand("privacy", "Privacy (online)", c => Launcher.LaunchUriAsync(new Uri("http://www.appdevpro.com/homeamation/homeamation-privacy/")))); 
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (App.HasInternetConnectivity)
            {
                Vm.CommandRefresh.Execute(true);
            }
        }
    }
}
