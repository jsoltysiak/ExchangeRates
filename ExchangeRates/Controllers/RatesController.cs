using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using ExchangeRates.Infrastructure;
using ExchangeRates.Models;
using ExchangeRates.Services;
using Newtonsoft.Json;

namespace ExchangeRates.Controllers.Api
{
    public class RatesController : ApiController
    {
        private readonly ICurrencyRatesService _exchangeRatesService;
        private readonly IXmlSerializer _xmlSerializer;

        public RatesController(ICurrencyRatesService exchangeRatesService, IXmlSerializer xmlSerializer)
        {
            _exchangeRatesService = exchangeRatesService;
            _xmlSerializer = xmlSerializer;
        }

        // GET: api/Rates
        public async Task<IEnumerable<Row>> Get()
        {
            var currentRates =  await _exchangeRatesService.GetCurrentRates();

            var currencyRates = _xmlSerializer.Deserialize<CurrencyRates>(currentRates);

            var interestingCurrencies = new[] {"USD", "EUR"};
            var filteredRates = currencyRates.Row.Where(r => interestingCurrencies.Any(c => c == r.SwiftCode));

            return filteredRates;
        }
    }
}
