using System;

namespace okala_task.Configs;

public class ExchangeratesConfig
{
    public const string Key = "ExchangeratesConfig";
    public string BaseUrl { get; set; }
    public string Token { get; set; }
    public List<string> DefaultSymbols { get; set; }
}