using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using HomeAmationViewModel.Pcl.Model;
using Newtonsoft.Json;

namespace HomeAmation.Service
{
    class GetJsonHistoricalTemperatureData 
    {
        // public const string uri = "http://192.168.1.200/homeautomation/TemperatureDataJson.php";

        public static async Task<string> GetHistoricalTemperatureData(string url)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }

        //public static async Task<ObservableCollection<HistoricalTemperatureData>> ParseJson()
        //{
        //    var strJson = await GetJsonHistoricalTemperatureData.GetHistoricalTemperatureData();
        //    var observableCollectionHistoricalTemperatureData = await JsonConvert.DeserializeObjectAsync<ObservableCollection<HistoricalTemperatureData>>(strJson);
        //    return observableCollectionHistoricalTemperatureData;
        //}
    }
}
