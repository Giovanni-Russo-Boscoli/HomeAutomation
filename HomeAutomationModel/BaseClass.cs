using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HomeAutomationModel
{
    public class BaseClass
    {
        //public static async Task<object> GetResponse(string _url, string _cmd)
        //{
        //    string url = _url;
        //    var jsonReturn = new object();
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(url);
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //        //GET Method  
        //        HttpResponseMessage response = new HttpResponseMessage();
        //        if (response.IsSuccessStatusCode)
        //        {
        //            response = await client.GetAsync(_cmd);
        //            var result = response.Content.ReadAsStringAsync().Result;
        //            jsonReturn = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
        //        }
        //        return jsonReturn;
        //    }
        //}
    }
}
