namespace SharedKernel.Main.Application.Common.Interfaces.Services;

public interface IGuardAgainstNullUpdate
{
    public void UpdateIfNotNullOrEmpty(ref string? property, string? newValue);

    public void UpdateIfNotNullOrEmpty(Action<string?> updateAction, string? newValue);
    
    public void UpdateIfNotNullOrEmpty(ref int? property, int? newValue);
}