namespace SharedKernel.Main.Application.Interfaces.Services;

public interface IGuardAgainstNullUpdate
{
    public void UpdateIfNotNullOrEmpty(ref string? property, string? newValue);
    public void UpdateIfNotNullOrEmpty(ref decimal property, decimal newValue);
    public void UpdateIfNotNullOrEmpty(ref uint? property, uint? newValue);
    public void UpdateIfNotNullOrEmpty(ref uint property, uint newValue);
    public void UpdateIfNotNullOrEmpty(ref int? property, int? newValue);
    public void UpdateIfNotNullOrEmpty(ref byte property, byte newValue);
    public void UpdateIfNotNullOrEmpty(Action<string?> updateAction, string? newValue);
    public void UpdateIfNotNullOrEmpty(Action<uint?> updateAction, uint? newValue);
    public void UpdateIfNotNullOrEmpty(ref byte? property, byte? newValue);
    public void UpdateIfNotNullOrEmpty(Action<byte?> updateAction, byte? newValue);
    public void UpdateIfNotNullOrEmpty(Action<uint> updateAction, uint newValue); 
    public void UpdateIfNotNullOrEmpty(Action<decimal> updateAction, decimal newValue);
    public void UpdateIfNotNullOrEmpty(Action<int?> updateAction, int? newValue); 
    public void UpdateIfNotNullOrEmpty(Action<byte> updateAction, byte newValue);
    public void UpdateIfNotNullOrEmpty(Action<DateTime> updateAction, DateTime newValue);
    public void UpdateIfNotNullOrEmpty(Action<bool> updateAction, bool newValue);
}