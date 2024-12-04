using okala_task.Dtos;

namespace okala_task.Services;

public interface ICurrencyService
{
    Task<ExchangeRatesDto> GetLatestRatesAsync(string baseCurrency, List<string>? symbols);
}
