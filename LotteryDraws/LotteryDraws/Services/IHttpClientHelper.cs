using System.Net.Http;
using System.Threading.Tasks;
using LotteryDraws.Models.Request;
using LotteryDraws.Models.Response;

namespace LotteryDraws.Services
{
    public interface IHttpClientHelper
    {
        Task<T> GetAsync<T>(HttpClient client, string url);
        Task<T> PostAsync<T>(HttpClient client, string url, object input);
        Task<T> PutAsync<T>(HttpClient client, string url, HttpContent contentPut);
    }
}
