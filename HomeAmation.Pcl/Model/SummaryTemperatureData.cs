using System;
using System.Runtime.Serialization;

namespace HomeAmation.Pcl.Model
{
    [DataContract]
    public class SummaryTemperatureData
    {
        [DataMember]
        public string DataLoggerDeviceName { get; set; } // jha 2/14/2012
        [DataMember]
        public float RecordedMinimumTemperature0 { get; set; }
        [DataMember]
        public DateTime RecordedMinimumTime { get; set; }
        [DataMember]
        public float RecordedMaximumTemperature0 { get; set; }
        [DataMember]
        public DateTime RecordedMaximumTime { get; set; }
        [DataMember]
        public float RecordedAverageTemperature0 { get; set; }
        [DataMember]
        public float ThirtyDayMinTemperature0 { get; set; }
        [DataMember]
        public DateTime ThirtyDayMinTime { get; set; }
        [DataMember]
        public float ThirtyDayMaxTemperature0 { get; set; }
        [DataMember]
        public DateTime ThirtyDayMaxTime { get; set; }
        [DataMember]
        public float ThirtyDayAvgTemperature0 { get; set; }
        [DataMember]
        public float CurrentTemperature0 { get; set; }
        [DataMember]
        public float CurrentTemperature1 { get; set; }
        [DataMember]
        public DateTime CurrentMeasuredTime { get; set; }

        //public string thirtyDayMaxTemperature0long { get { return thirtyDayMaxTemperature0.ToString("{c}"); } }
    }
}
