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
        private const string JsonApplicationType = "application/json";
        #region Abstract, Async, static HTTP functions for GET, POST, PUT, DELETE               
        public async Task<T> GetAsync<T>(HttpClient client, string url)
        {
            T data;

            
            using (HttpResponseMessage response = await client.GetAsync(url))
            using (HttpContent content = response.Content)
            {
                string d = await content.ReadAsStringAsync();
                if (d != null)
                {
                    data = JsonConvert.DeserializeObject<T>(d);
                    return (T)data;
                }
            }
            

            Object o = new Object();
            return (T)o;
        }

        public async Task<T> PostAsync<T>(HttpClient client, string url, object input)
        {
            T data;
            var serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver()
            };

            var contentToSend = JsonConvert.SerializeObject(input, serializerSettings);

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

        public async Task<T> PutAsync<T>(HttpClient client, string url, HttpContent contentPut)
        {
            T data;

            
            using (HttpResponseMessage response = await client.PutAsync(url, contentPut))
            using (HttpContent content = response.Content)
            {
                string d = await content.ReadAsStringAsync();
                if (d != null)
                {
                    data = JsonConvert.DeserializeObject<T>(d);
                    return (T)data;
                }
            }
            Object o = new Object();
            return (T)o;
        }
        #endregion

    }
}