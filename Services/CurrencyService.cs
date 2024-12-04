// Services/CurrencyConversionService.cs
using Microsoft.Extensions.Options;
using okala_task.Configs;
using okala_task.Dtos;
using okala_task.Utilities;

namespace okala_task.Services;

public class CurrencyService : ICurrencyService
{
    private readonly IHttpRequest _httpClient;
    private readonly ExchangeratesConfig _config;
    public CurrencyService(IHttpRequest httpClient, IOptions<ExchangeratesConfig> options)
    {
        _httpClient = httpClient;
        _config = options.Value;
    }

    public async Task<ExchangeRatesDto> GetLatestRatesAsync(string baseCurrency, List<string>? symbols)
    {
        if (symbols == null || symbols.Count == 0)
            symbols = _config.DefaultSymbols;

        var joinedSymbols = string.Join(",", symbols);
        var url = $"{_config.BaseUrl}/latest?access_key={_config.Token}&base={baseCurrency}&symbols={joinedSymbols}";
        var response = await _httpClient.GetAsync<ExchangeRatesDto>(url, null);
        return response;
    }

}
