using System;

namespace HomeAmation.Pcl.Model
{
    public class HistoricalTemperatureData
    {
        public int Id { get; set; }
        public string DataLoggerName { get; set; }
        public DateTime Time { get; set; }
        public double Temperature0 { get; set; }
        public double Temperature1 { get; set; }
    }
}
