using Microsoft.AspNetCore.Mvc;
using okala_task.Dtos;
using okala_task.Services;

namespace okala_task.Controllers;

[ApiController]
[Route("[controller]")]
public class CryptoController : ControllerBase
{
    private readonly ICurrencyService _currencyService;

    public CryptoController(ICurrencyService currencyService)
    {
        _currencyService = currencyService;
    }


    [HttpPost("get-crypto-info", Name = "GetCryptoInfo")]
    public async Task<ActionResult<ExchangeRatesDto>> GetCryptoInfo([FromBody] GetCryptoInfoInput input)
    {
        var quote = await _currencyService.GetLatestRatesAsync(input.NormalizeBase, input.Types);
        return Ok(quote);
    }

}
