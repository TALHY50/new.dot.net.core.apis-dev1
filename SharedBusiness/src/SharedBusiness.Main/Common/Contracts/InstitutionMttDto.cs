
namespace SharedBusiness.Main.Common.Contracts
{
    public record InstitutionMttDto
    (
        uint id,
        uint InstitutionId,
        uint MttId,
        byte CommissionType,
        uint? CommissionCurrencyId,
        decimal CommissionPercentage,
        decimal CommissionFixed,
        uint? CompanyId
     );
}
