using SharedKernel.Main.Application.Enums;

namespace SharedBusiness.Main.IMT.Contracts.Contracts.Responses
{
    public record RegionDto(
        uint id,
        string? name,
        uint? companyId,
        StatusValues status
        );
}
