namespace SharedBusiness.Main.Common.Contracts.Responses
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
