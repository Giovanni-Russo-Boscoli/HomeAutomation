using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HomeAutomationService.Concrete
{
    public class BaseService
    {
        public static async Task<string> GetResponse(string _url, string _cmd)
        {
            string url = _url;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //GET Method  
                HttpResponseMessage response = new HttpResponseMessage( );
                if (response.IsSuccessStatusCode)
                {
                    response = await client.GetAsync(_cmd);
                    return response.Content.ReadAsStringAsync().Result;
                }
                return string.Empty;
            }
        }
    }
}
