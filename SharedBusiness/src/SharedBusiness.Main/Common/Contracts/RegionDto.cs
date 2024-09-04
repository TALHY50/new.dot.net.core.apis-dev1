using SharedKernel.Main.Application.Enums;

namespace SharedBusiness.Main.Common.Contracts
{
    public record RegionDto(
        uint id,
        string? name,
        uint? companyId,
        StatusValues status
        );
}
