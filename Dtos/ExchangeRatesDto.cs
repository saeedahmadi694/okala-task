using okala_task.Configs;

namespace okala_task.Dtos;

public record GetCryptoInfoInput(string Base, List<string>? Types)
{
    public string NormalizeBase => Base.ToUpper();
};