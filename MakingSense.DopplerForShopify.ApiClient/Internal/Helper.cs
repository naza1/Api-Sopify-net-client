using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MakingSense.DopplerForShopify.ApiClient.Internal
{
    public static class Helper
    {
        public static HttpClient httpClient = new HttpClient { BaseAddress = new Uri("http://google.com") };

        public static T WaitAndGetValue<T>(this Task<T> task)
        {
            try
            {
                task.Wait();
                return task.Result;
            }
            catch (Exception e)
            {
                throw e.InnerException ?? e;
            }
        }

        // Read a response as String
        public static string GetContentAsString(this HttpResponseMessage response)
        {
            return response.Content.ReadAsStringAsync().WaitAndGetValue();
        }


        // Read a response as Object
        public static JObject GetContentAsJObject(this HttpResponseMessage response)
        {
            return JObject.Parse(response.GetContentAsString());
        }

        public static T GetContentAs<T>(this HttpResponseMessage response)
        {
            return JsonConvert.DeserializeObject<T>(response.GetContentAsString());
        }

        //Create new Request and return HttpReponseMessage
        public static HttpResponseMessage CreateRequest(string uri, HttpMethod method, string json = null, string apiKey = null)
        {
            apiKey = apiKey ?? "APIKEY";
            using (var request = new HttpRequestMessage(method, uri))
            {
                request.Headers.Add("Authorization", "token " + apiKey);
                if (json != null)
                    request.Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var response = httpClient.SendAsync(request).WaitAndGetValue();
                Thread.Sleep(50);
                return response;
            }
        }
    }
}