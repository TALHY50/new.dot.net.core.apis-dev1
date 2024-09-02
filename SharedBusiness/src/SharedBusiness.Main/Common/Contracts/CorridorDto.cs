using SharedKernel.Main.Application.Enums;

namespace SharedBusiness.Main.IMT.Contracts.Contracts.Responses
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
