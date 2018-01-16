using System.Net.Http;
using System.Threading.Tasks;

namespace ExchangeRates.Infrastructure
{
    public interface IHttpClient
    {
        Task<string> GetStringAsync(string requestUri);
    }

    public class HttpClientImpl : IHttpClient
    {
        private readonly HttpClient _httpClient;

        public HttpClientImpl()
        {
            _httpClient = new HttpClient();
        }

        public Task<string> GetStringAsync(string requestUri)
        {
            return _httpClient.GetStringAsync(requestUri);
        }
    }
}