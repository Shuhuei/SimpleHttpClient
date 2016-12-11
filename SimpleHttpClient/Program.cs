using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using System.Web;

namespace SimpleHttpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            var acceptHeader =
                new MediaTypeWithQualityHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Accept.Add(acceptHeader);
            httpClient.DefaultRequestHeaders.Authorization
              = new AuthenticationHeaderValue("Bearer", "token data");
            httpClient.DefaultRequestHeaders.Add("Header_key", "Header value");
            HttpResponseMessage httpRes = httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts").Result;

            if (httpRes.IsSuccessStatusCode)
            {
                var strRes = httpRes.Content.ReadAsStringAsync().Result;
                JArray jValue = JArray.Parse(strRes);

                //                JObject jRes = JObject.Parse(strRes);
                //                JArray jValue = (JArray)jRes["value"];

                foreach (JObject jItem in jValue)
                {
                    Console.WriteLine($"Id={((JValue)jItem["id"]).Value},Title = {((JValue)jItem["title"]).Value}");
                }
            }

            Console.Read();
        }
    }
}
