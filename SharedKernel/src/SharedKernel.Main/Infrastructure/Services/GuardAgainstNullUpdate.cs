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
    
    public void UpdateIfNotNullOrEmpty(ref decimal property, decimal newValue)
    {
        if (newValue != null)
        {
            property = newValue;
        }
    }
    public void UpdateIfNotNullOrEmpty(ref uint? property, uint? newValue)
    {
        if (newValue != null)
        {
            property = newValue;
        }
    }

    public void UpdateIfNotNullOrEmpty(Action<uint?> updateAction, uint? newValue)
    {
        if (newValue != 0)
        {
            updateAction(newValue);
        }
    }

    public void UpdateIfNotNullOrEmpty(ref byte? property, byte? newValue)
    {
        if (newValue != null)
        {
            property = newValue;
        }
    }

    public void UpdateIfNotNullOrEmpty(ref uint property, uint newValue)
    {
        if (newValue != null)
        {
            property = newValue;
        }
    }

    public void UpdateIfNotNullOrEmpty(Action<byte?> updateAction, byte? newValue)
    {
    
        if (newValue != null)
        {
            updateAction(newValue);
        }
    }

    public void UpdateIfNotNullOrEmpty(Action<uint> updateAction, uint newValue)
    {
        if (newValue != null)
        {
            updateAction(newValue);
        }
    }

    public void UpdateIfNotNullOrEmpty(Action<decimal> updateAction, decimal newValue)
    {
        if (newValue != null)
        {
            updateAction(newValue);
        }
    }

    public void UpdateIfNotNullOrEmpty(Action<int?> updateAction, int? newValue)
    {
        if (newValue != null)
        {
            updateAction(newValue);
        }
    }

    public void UpdateIfNotNullOrEmpty(ref byte property, byte newValue)
    {
        if (newValue != 0)
        {
            property = newValue;
        }
    }

    public void UpdateIfNotNullOrEmpty(Action<byte> updateAction, byte newValue)
    {
        if (newValue != null)
        {
            updateAction(newValue);
        }
    }

    public void UpdateIfNotNullOrEmpty(Action<System.DateTime> updateAction, System.DateTime newValue)
    {
        if (newValue != null)
        {
            updateAction(newValue);
        }
    }

    public void UpdateIfNotNullOrEmpty(Action<bool> updateAction, bool newValue)
    {
        if (newValue != null)
        {
            updateAction(newValue);
        }
    }

    public void UpdateIfNotNullOrEmpty(ref bool property, bool newValue)
    {
        if (newValue == true)
        {
            property = newValue;
        }
    }

    public void UpdateIfNotNullOrEmpty(Action<sbyte> updateAction, sbyte newValue)
    {
        if (newValue != null)
        {
            updateAction(newValue);
        }
    }
}