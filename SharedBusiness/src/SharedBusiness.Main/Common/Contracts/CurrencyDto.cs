namespace SharedBusiness.Main.Common.Contracts
{
    public record CurrencyDto
    (
        uint id,
        string? Code,
        string? IsoCode,
        string? Name,
        string? Symbol
    );
}
