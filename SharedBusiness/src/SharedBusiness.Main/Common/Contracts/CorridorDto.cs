namespace SharedBusiness.Main.Common.Contracts
{
    public record CorridorDto
    (
        uint id,
        uint? SourceCountryId,
        uint? DestinationCountryId,
        uint? SourceCurrencyId,
        uint? DestinationCurrencyId,
        uint? CompanyId
    );
}
