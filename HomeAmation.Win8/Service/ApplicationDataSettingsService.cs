using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace HomeAmation.Service
{
    public class ApplicationDataSettingsService
    {
        private ApplicationDataContainer localSettings;

        public ApplicationDataSettingsService()
        {
            localSettings = ApplicationData.Current.LocalSettings;
            //SummaryDataUrl = localSettings.Values["SummaryDataUrl"].ToString();
            //HistoricalDataUrl = localSettings.Values["HistoricalDataUrl"].ToString();
            LoadSettings();
        }

        public bool SettingExists(string setting)
        {
            object obj = localSettings.Values[setting];
            if (obj == null)
                return false;
            return true;
        }

        public string SummaryDataUrl { get; set; }
        public string HistoricalDataUrl { get; set; }

        private void LoadSettings()
        {
            // ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
            object stdUrl = localSettings.Values["SummaryDataUrl"];
            if (stdUrl != null)
            {
                SummaryDataUrl = localSettings.Values["SummaryDataUrl"].ToString();
                HistoricalDataUrl = localSettings.Values["HistoricalDataUrl"].ToString();
            }
            else
            {
                // looks like there are no current saved urls. load and save the defaults.
                SummaryDataUrl = App.SummaryDataUrl;
                HistoricalDataUrl = App.HistoricalDataUrl;
                SaveSettings();
            }
        }

        public void SaveSettings()
        {
            localSettings.Values["SummaryDataUrl"] = SummaryDataUrl;
            localSettings.Values["HistoricalDataUrl"] = HistoricalDataUrl;
        }

        public void RestoreDefaults()
        {
            SummaryDataUrl = App.SummaryDataUrl;
            HistoricalDataUrl = App.HistoricalDataUrl;
            SaveSettings();
        }
        
        //public void SaveStdUrl(string val)
        //{
        //    localSettings.Values["SummaryDataUrl"] = val;
        //}

        //public void SaveHtdUrl(string val)
        //{
        //    localSettings.Values["HistoricalDataUrl"] = val;
        //}

        //private void SaveSetting(string SummaryDataUrl, string HistoricalDataUrl)
        //{
        //    localSettings.Values["SummaryDataUrl"] = SummaryDataUrl;
        //    localSettings.Values["HistoricalDataUrl"] = HistoricalDataUrl;
        //}
    }
}
