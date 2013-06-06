using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HomeAmation.Service;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace HomeAmation.Controls
{
    public sealed partial class GeneralSettings : UserControl
    {
        private ApplicationDataSettingsService applicationDataSettingsService;

        public GeneralSettings()
        {
            applicationDataSettingsService = new ApplicationDataSettingsService();
            this.InitializeComponent();
            LoadSettings();
        }

        private void LoadSettings()
        {
            TextBoxStdUrl.Text = applicationDataSettingsService.SummaryDataUrl;
            TextBoxHtdUrl.Text = applicationDataSettingsService.HistoricalDataUrl;

            //ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
            //object stdUrl = localSettings.Values["SummaryDataUrl"];
            //if (stdUrl != null)
            //{
            //    SummaryDataUrl.Text = localSettings.Values["SummaryDataUrl"].ToString();
            //    HistoricalDataUrl.Text = localSettings.Values["HistoricalDataUrl"].ToString();
            //}
            //else
            //{
            //    // looks like there are no current saved urls. load and save the defaults.
            //    SummaryDataUrl.Text = App.SummaryDataUrl;
            //    HistoricalDataUrl.Text = App.HistoricalDataUrl;
            //    SaveSettings(localSettings);
            //}
        }

        private void ButtonSaveSettings_Click(object sender, RoutedEventArgs e)
        {
            SaveSettings();
        }

        private void SaveSettings()
        {
            applicationDataSettingsService.SummaryDataUrl = TextBoxStdUrl.Text;
            applicationDataSettingsService.HistoricalDataUrl = TextBoxHtdUrl.Text;
            applicationDataSettingsService.SaveSettings();

            //localSettings.Values["SummaryDataUrl"] = SummaryDataUrl.Text;
            //localSettings.Values["HistoricalDataUrl"] = HistoricalDataUrl.Text;
        }

        private void ButtonRestoreDefaults_OnClick(object sender, RoutedEventArgs e)
        {
            applicationDataSettingsService.RestoreDefaults(); // restore from App defaults
            LoadSettings(); // load the textboxes
            SaveSettings();
        }
    }
}
