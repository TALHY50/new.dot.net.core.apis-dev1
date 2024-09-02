using SharedKernel.Main.Application.Interfaces.Services;

namespace SharedKernel.Main.Infrastructure.Services;

public class GuardAgainstNullUpdate : IGuardAgainstNullUpdate
{
    public void UpdateIfNotNullOrEmpty(ref string? property, string? newValue)
    {
        if (!string.IsNullOrEmpty(newValue))
        {
            property = newValue;
        }
    }
    
    public void UpdateIfNotNullOrEmpty(Action<string?> updateAction, string? newValue)
    {
        if (!string.IsNullOrEmpty(newValue))
        {
            updateAction(newValue);
        }
    }

    public void UpdateIfNotNullOrEmpty(ref int? property, int? newValue)
    {
        if (newValue != null)
        {
            property = newValue;
        }
    }
}