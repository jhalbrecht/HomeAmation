﻿using System;

namespace HomeAmation.Service
{
    public interface IIsolatedStorageService
    {
        string SummaryDataUrl { get; set; }
        string SummaryDataUrlSettingKeyName { get; set; }
                
        string HistoricalDataUrl { get; set; }
        string HistoricalDataUrlSettingKeyName { get; set; }

        bool IsEnableHistoricalDataDisplayChecked { get; set; }
        string IsEnableHistoricalDataDisplayCheckedSettingKeyName { get; set; }

        bool AppHasPreviouslyRun { get; set; }
        bool AddOrUpdateValue(string p, Object value);
        bool Contains(string p);
    }
}