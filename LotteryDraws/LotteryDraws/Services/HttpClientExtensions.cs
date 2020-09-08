using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace LotteryDraws.Services
{
    public class HttpClientExtensions
    {
        /*private const string JsonApplicationType = "application/json";
        public static async Task<IResult<T>> GetAsync<T>(this HttpClient client, string uri)
        {
            var response = await client.GetAsync(uri);

            return await ProcessResponse<T>(response);
        }

        public static async Task<T> PostAsync<T>(this HttpClient client, string uri, object data)
        {
            var serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var content = JsonConvert.SerializeObject(data, serializerSettings);

            var response = await client.PostAsync(uri, new StringContent(content, Encoding.UTF8, JsonApplicationType));

            return await ProcessResponse<T>(response);
        }

        private static async Task<T> ProcessResponse<T>(HttpResponseMessage response)
        {
            var serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var responseObject = JsonConvert.DeserializeObject<T>(responseBody, serializerSettings);
                return new Result<T>(responseObject, response.StatusCode, responseBody);
            }

            var errorResponse = await response.Content.ReadAsStringAsync();
            try
            {
                var error = JsonConvert.DeserializeObject<ErrorResponse>(errorResponse, serializerSettings);
                return new Result<T>(error, response.StatusCode, errorResponse);
            }
            catch (Exception)
            {
                var error = new ErrorResponse
                {
                    Message = "Could not deserialize error response",
                    Status = response.StatusCode
                };
                return new Result<T>(error, response.StatusCode, errorResponse);
            }
        }*/
    }
}
