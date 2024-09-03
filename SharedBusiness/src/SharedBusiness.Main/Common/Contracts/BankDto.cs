namespace SharedBusiness.Main.Common.Contracts
{
    public record BankDto(
        uint id,
        string? code,
        string? name,
        string? displayName,
        string? url,
        string? logo
        );
}
