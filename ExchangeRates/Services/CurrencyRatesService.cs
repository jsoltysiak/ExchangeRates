using System.Threading.Tasks;
using System.Web.Configuration;
using ExchangeRates.Infrastructure;

namespace ExchangeRates.Services
{
    public interface ICurrencyRatesService
    {
        Task<string> GetCurrentRates();
    }

    public class CurrencyRatesService : ICurrencyRatesService
    {
        private readonly IHttpClient _httpClient;

        public CurrencyRatesService(IHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetCurrentRates()
        {
            var ratesUrl = WebConfigurationManager.AppSettings["RatesUrl"];
            return await _httpClient.GetStringAsync(ratesUrl);
        }
    }
}