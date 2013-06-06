using System;

namespace HomeAmation.Pcl.Model
{
    public class DataService : IDataService
    {
        private string url = "http://jeffa.org:81/ha/SummaryData.php";
       

        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to connect to the actual data service
        
            var item = new DataItem("Welcome to jMVVM Light");
            callback(item, null);
        }

        //public async Void GetXml()
        //{

        //    var uri = new Uri("http://jeffa.org:81/ha/SummaryData.php");
        //    var client = new HttpClient();
        //    var opContent = (await client.GetAsync(uri)).Content;
        //    string foo = await opContent.ReadAsStringAsync();


        //    //var uri = new Uri(url);
        //    //HttpClient client = new HttpClient();
        //    //var xmlString = await (client.GetAsync(uri)).Content;
        //    //return xmlString;
        //}
    }
}