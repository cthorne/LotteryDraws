using System.Net.Http;
using System.Threading.Tasks;

namespace LotteryDraws.Services
{
    public interface IHttpClientHelper
    {
        Task<T> PostAsync<T>(HttpClient client, string url, object input);
    }
}
