namespace SharedBusiness.Main.Common.Contracts
{
    public record TaxRateDto(
        uint id,
        byte tax_type,
        uint? corridor_id,
        uint? country_id,
        uint? tax_currency_id,
        decimal tax_percentage,
        decimal tax_fixed,
        uint? company_id
        );
}
