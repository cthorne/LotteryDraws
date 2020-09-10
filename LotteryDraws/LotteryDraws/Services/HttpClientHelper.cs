using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;

namespace LotteryDraws.Services
{
    public class HttpClientHelper : IHttpClientHelper
    {
        // Adapted from https://lynndemarest.com/2020/01/generic-class-makes-net-core-httpclient-calls-new/
        // https://lynndemarest.com/2020/01/abstract-class-to-make-net-core-httpclient-calls/
        private const string JsonApplicationType = "application/json";
        #region Abstract, Async, static HTTP functions for GET, POST, PUT, DELETE  
        public async Task<T> PostAsync<T>(HttpClient client, string url, object input)
        {
            T data;

            var contentToSend = JsonConvert.SerializeObject(input);

            using (HttpResponseMessage response = await client.PostAsync(client.BaseAddress + url,
                new StringContent(contentToSend, Encoding.UTF8, JsonApplicationType)))
            {
                using (HttpContent content = response.Content)
                {
                    string d = await content.ReadAsStringAsync();
                    if (d != null)
                    {
                        data = JsonConvert.DeserializeObject<T>(d);
                        return (T) data;
                    }
                }
            }

            Object o = new Object();
            return (T)o;
        }
        #endregion

    }
}