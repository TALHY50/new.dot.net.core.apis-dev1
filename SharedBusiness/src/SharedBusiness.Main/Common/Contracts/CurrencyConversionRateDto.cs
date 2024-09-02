namespace SharedBusiness.Main.IMT.Contracts.Contracts.Responses
{
    public record CurrencyConversionRateDto
    (
        uint id,
        uint corridor_id,
        decimal exchange_rate,
        decimal fx_spread,
        uint? company_id
    );
}
