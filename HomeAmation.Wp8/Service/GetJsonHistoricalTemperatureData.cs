// using System.Net.Http;

namespace HomeAmation.Service
{
    class GetJsonHistoricalTemperatureData 
    {
        //public const string uri = "http://192.168.1.200/homeautomation/TemperatureDataJson.php";

        //public static async Task<string> GetHistoricalTemperatureData()
        //{
        //    HttpClient client = new HttpClient();

        //    // client.DefaultRequestHeaders.Add("application/json;odata=verbose");
        //    //client.Headers["Accept"] = "application/json;odata=verbose";
        //    //client.Headers["MaxDataServiceVersion"] = "3.0";
        //    HttpResponseMessage response = await client.GetAsync(uri);
        //    return await response.Content.ReadAsStringAsync();
        //}

        //public static async Task<ObservableCollection<HistoricalTemperatureData>> ParseJson()
        //{
        //    var strJson = await GetJsonHistoricalTemperatureData.GetHistoricalTemperatureData();
        //    var observableCollectionHistoricalTemperatureData = await JsonConvert.DeserializeObjectAsync<ObservableCollection<HistoricalTemperatureData>>(strJson);
        //    return observableCollectionHistoricalTemperatureData;

        //    // return await JsonConvert.DeserializeObjectAsync<ObservableCollection<HistoricalTemperatureData>>(GetHistoricalTemperatureData().ToString());
        //}
    }
}
