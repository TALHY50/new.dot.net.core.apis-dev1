namespace SharedBusiness.Main.Common.Contracts
{
    public record PayerDto
        (
        uint id,
        string Name,
        uint? ProviderId,
        uint? CorridorId,
        string InternalPayerId,
        uint? FundCurrencyId,
        decimal Increment,
        byte MoneyPrecision,
        uint? ServiceMethodId,
        string TransactionTypeIds,
        decimal SourceAmountMax,
        decimal SourceAmountMin,
        decimal DestinationAmountMax,
        decimal DestinationAmountMin,
        uint? CotCurrencyId,
        decimal CotPercentage,
        decimal CotFixed,
        decimal FxSpread,
        string PaymentSpeed,
        uint? CompanyId);
}
