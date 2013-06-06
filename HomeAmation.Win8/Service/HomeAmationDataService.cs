using System.Net.Http;
using HomeAmation.Pcl.Model;
using HomeAmation.Pcl.Service;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace HomeAmation.Service
{
    public class HomeAmationDataService : IHomeAmationDataService
    {
        // private ApplicationDataSettingsService applicationDataSettingsService;

        public HomeAmationDataService()
        {
            // applicationDataSettingsService = new ApplicationDataSettingsService();
        }

        public async Task<SummaryTemperatureData> GetStdAsync()
        {
            // var uri = new Uri("http://jeffa.org:81/ha/SummaryData.php");
            //var uri = new Uri(App.SummaryDataUrl);
            //var client = new HttpClient();
            //var opContent = (await client.GetAsync(uri)).Content;
            //string foo = await opContent.ReadAsStringAsync();
            //var fooo = JsonConvert.DeserializeObjectAsync<SummaryTemperatureData>(foo);
            //return await fooo;
            var applicationDataSettingsService = new ApplicationDataSettingsService();
            try
            {
            // ToDo need to wrap this a bit. error checking. disposal....
            WebHeaderCollection headers = new WebHeaderCollection();
            WebRequest request = WebRequest.Create(new Uri(applicationDataSettingsService.SummaryDataUrl));
            request.ContentType = "application/xml";
            WebResponse response = await request.GetResponseAsync();
            // response.Close(); // ?? hmmm
            Debug.WriteLine("\nThe HttpHeaders are \n{0}", request.Headers);
            Stream inputStream = response.GetResponseStream();
            XmlReader xmlReader = XmlReader.Create(inputStream);
            XmlSerializer xml = new XmlSerializer(typeof(SummaryTemperatureData));
            var stdXml = (SummaryTemperatureData)xml.Deserialize(xmlReader);
            return stdXml;
            }
            catch (Exception e)
            {
                Utility.Log(this, e.ToString());
                return null;
            }
        }

        public SummaryTemperatureData GetStd()
        {
            return MockStd();
        }

        public async Task<ObservableCollection<HistoricalTemperatureData>> GetWeekHtdes()
        {
            var applicationDataSettingsService = new ApplicationDataSettingsService();
            try
            {
                JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings();
                jsonSerializerSettings.DateParseHandling = DateParseHandling.None;
                // var strJson = await GetJsonHistoricalTemperatureData.GetHistoricalTemperatureData(applicationDataSettingsService.HistoricalDataUrl);
                var strJson = await GetHistoricalTemperatureData(applicationDataSettingsService.HistoricalDataUrl);
                return await JsonConvert.DeserializeObjectAsync<ObservableCollection<HistoricalTemperatureData>>(strJson, jsonSerializerSettings);
            }
            catch (Exception e)
            {
                Utility.Log(this, e.ToString());
                return null;
            }
        }

        public static async Task<string> GetHistoricalTemperatureData(string url)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }

        private SummaryTemperatureData MockStd()
        {
            return new SummaryTemperatureData
                {
                    DataLoggerDeviceName = "Design Mocking bird brain",
                    CurrentTemperature0 = 77,
                    CurrentTemperature1 = 88,
                    CurrentMeasuredTime = DateTime.Now,
                };
        }
    }
}
