namespace SharedBusiness.Main.Common.Contracts
{
    public record InstitutionFundDto(
    uint id,
    uint institution_id,
    uint provider_id,
    uint fund_country_id,
    uint fund_currency_id,
    string account_number,
    decimal starting_amount,
    decimal current_amount,
    uint? company_id
    );
}
