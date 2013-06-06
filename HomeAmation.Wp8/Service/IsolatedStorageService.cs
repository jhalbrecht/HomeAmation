using System;
using System.Diagnostics;
using System.IO.IsolatedStorage;

namespace HomeAmation.Service
{
    public class IsolatedStorageService : IIsolatedStorageService
    {
        IsolatedStorageSettings isolatedStore;

        /// <summary>
        /// Default constructor
        /// Initializes a new instance of the IsolatedStorageService
        /// </summary>
        public IsolatedStorageService()
        {
            try
            {
                isolatedStore = IsolatedStorageSettings.ApplicationSettings;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception while using IsolatedStorageSettings: " + e.ToString());
            }
        }

        private string SummaryDataUrlSettingDefault = App.DefaultSummaryDataUrl;
        private string _SummaryDataUrlSettingKeyName = "SummaryDataUrlSetting";
        public string SummaryDataUrlSettingKeyName
        {
            get { return _SummaryDataUrlSettingKeyName; }
            set { _SummaryDataUrlSettingKeyName = value; }
        }

        private string HistoricalDataUrlSettingDefault = App.DefaultHistoricalDataUrl;
        private string _HistoricalDataUrlSettingKeyName = "HistoricalDataUrlSetting";
        public string HistoricalDataUrlSettingKeyName
        {
            get { return _HistoricalDataUrlSettingKeyName; }
            set { _HistoricalDataUrlSettingKeyName = value; }
        }

        private bool IsEnableHistoricalDataDisplayCheckedSettingDefault = false;
        private string _IsEnableHistoricalDataDisplayCheckedSettingKeyName = "IsEnableHistoricalDataDisplayCheckedSetting";
        public string IsEnableHistoricalDataDisplayCheckedSettingKeyName 
        {
            get { return _IsEnableHistoricalDataDisplayCheckedSettingKeyName; }
            set { _IsEnableHistoricalDataDisplayCheckedSettingKeyName = value;}
        }

        public bool AppHasPreviouslyRun
        {
            get
            {
                return Contains("AppHasRun");
                // return appHasPreviouslyRun;
            }
             set
             {
                 ; // AddOrUpdateValue(appHasPreviouslyRun, (string)value);
             }
        }

        public bool Contains(string key)
        {
            return isolatedStore.Contains(key);
        }

        /// <summary>
        /// Property to get and set a HomeAmationDataUrlSetting Setting Key.
        /// </summary>
        public string HistoricalDataUrl
        {
            get
            {
                return GetValueOrDefault<string>(HistoricalDataUrlSettingKeyName, HistoricalDataUrlSettingDefault);
            }
            set
            {
                AddOrUpdateValue(HistoricalDataUrlSettingKeyName, value);
                Save();
            }
        }

        /// <summary>
        /// Property to get and set a HomeAmationDataStdSetting Setting Key.
        /// </summary>
        public string SummaryDataUrl
        {
            get
            {
                return GetValueOrDefault<string>(SummaryDataUrlSettingKeyName, SummaryDataUrlSettingDefault);
            }
            set
            {
                AddOrUpdateValue(SummaryDataUrlSettingKeyName, value);
                Save();
            }
        }

        public bool IsEnableHistoricalDataDisplayChecked
        {
            get { return GetValueOrDefault<bool>(IsEnableHistoricalDataDisplayCheckedSettingKeyName, IsEnableHistoricalDataDisplayCheckedSettingDefault); }
            set
            {
                AddOrUpdateValue(IsEnableHistoricalDataDisplayCheckedSettingKeyName, value);
                Save(); 
            }
        }

        /// <summary>
        /// Update a setting value for our application. If the setting does not
        /// exist, then add the setting.
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool AddOrUpdateValue(string Key, Object value)
        {
            bool valueChanged = false;

            // If the key exists
            if (isolatedStore.Contains(Key))
            {
                // If the value has changed
                if (isolatedStore[Key] != value)
                {
                    // Store the new value
                    isolatedStore[Key] = value;
                    valueChanged = true;
                    
                    isolatedStore.Save(); 
                    // Messenger.Default.Send("UpdateHtd");
                }
            }
            // Otherwise create the key.
            else
            {
                isolatedStore.Add(Key, value);
                valueChanged = true;
                
                isolatedStore.Save(); 
            }
            return valueChanged;
        }

        /// <summary>
        /// Get the current value of the setting, or if it is not found, set the 
        /// setting to the default setting.
        /// </summary>
        /// <typeparam name="valueType"></typeparam>
        /// <param name="Key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public valueType GetValueOrDefault<valueType>(string Key, valueType defaultValue)
        {
            valueType value;

            // If the key exists, retrieve the value.
            if (isolatedStore.Contains(Key))
            {
                value = (valueType)isolatedStore[Key];
            }
            // Otherwise, use the default value.
            else
            {
                value = defaultValue;
            }
            return value;
        }

        /// <summary>
        /// Save the settings.
        /// </summary>
        public void Save()
        {
            isolatedStore.Save();
        }
    }
}
