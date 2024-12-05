using okala_task.Configs;
using System.Text.Json.Serialization;

namespace okala_task.Dtos;

public record GetCryptoInfoInput(string Base, List<string>? Types)
{
    [JsonIgnore]
    public string NormalizeBase => Base.ToUpper();
};