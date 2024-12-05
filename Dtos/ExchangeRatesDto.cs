using Newtonsoft.Json;
using okala_task.Configs;

namespace okala_task.Dtos;

public class ExchangeRatesDto
{
    public string Base { get; set; }
    public DateTime Date { get; set; }
    public Dictionary<string, decimal> Rates { get; set; }
}