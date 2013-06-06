using System.Collections.ObjectModel;
using System.Threading.Tasks;
using HomeAmation.Pcl.Model;

namespace HomeAmation.Pcl.Service
{
    public interface IHomeAmationDataService
    {
        Task<SummaryTemperatureData> GetStdAsync();
        SummaryTemperatureData GetStd();

        Task<ObservableCollection<HistoricalTemperatureData>> GetWeekHtdes();
    }
}
