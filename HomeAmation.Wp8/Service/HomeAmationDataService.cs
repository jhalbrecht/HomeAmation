using HomeAmation.Pcl.Model;
using HomeAmation.Pcl.Service;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace HomeAmation.Service
{
    public class HomeAmationDataService : IHomeAmationDataService
    {
        public async Task<SummaryTemperatureData> GetStdAsync()
        {
            try 
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml");
                HttpResponseMessage response = await client.GetAsync(App.SummaryDataUrl);
                var content = await response.Content.ReadAsStringAsync();
                // var t = await MakeAsyncRequest(App.DefaultSummaryDataUrl);
                StringReader stringReader = new StringReader(content);
                XmlReader xmlReader = XmlReader.Create(stringReader);
                XmlSerializer xml = new XmlSerializer(typeof(SummaryTemperatureData));
                return (SummaryTemperatureData)xml.Deserialize(xmlReader);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("caught ex {0} ", ex); 
                return null;
            }
        }

        public SummaryTemperatureData GetStd()
        {
            throw new NotImplementedException();
        }

        public async Task<ObservableCollection<HistoricalTemperatureData>> GetWeekHtdes()
        {
            {
                try
                {
                    JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings();
                    jsonSerializerSettings.DateParseHandling = DateParseHandling.None;
                    // var strJson = await GetJsonHistoricalTemperatureData.GetHistoricalTemperatureData(applicationDataSettingsService.HistoricalDataUrl);
                    var strJson = await GetHistoricalTemperatureData(App.HistoricalDataUrl);
                    return await JsonConvert.DeserializeObjectAsync<ObservableCollection<HistoricalTemperatureData>>(strJson, jsonSerializerSettings);
                }
                catch (Exception e)
                {
                    Utility.Log(this, e.ToString());
                    return null;
                }
            }
        }

        public static async Task<string> GetHistoricalTemperatureData(string url)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
