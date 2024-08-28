namespace SharedBusiness.Main.IMT.Domain.Entities;

/// <summary>
/// Type : Master, payers are the corridor setups under a provider like Thunes, a payer is acting like a bank terminal, most of the data are operational, will be set as MTT&apos;s values, here to crosscheck
/// </summary>
public partial class Payer
{
    public uint Id { get; set; }

    public string Name { get; set; } = null!;

    public uint? ProviderId { get; set; }

    public uint? CorridorId { get; set; }

    public string InternalPayerId { get; set; } = null!;

    public uint? FundCurrencyId { get; set; }

    public decimal Increment { get; set; }

    public byte MoneyPrecision { get; set; }

    public uint? ServiceMethodId { get; set; }

    /// <summary>
    /// CSV of transaction_type_id values
    /// </summary>
    public string TransactionTypeIds { get; set; } = null!;

    public decimal SourceAmountMax { get; set; }

    public decimal SourceAmountMin { get; set; }

    public decimal DestinationAmountMax { get; set; }

    public decimal DestinationAmountMin { get; set; }

    public uint? CotCurrencyId { get; set; }

    public decimal CotPercentage { get; set; }

    public decimal CotFixed { get; set; }

    public decimal FxSpread { get; set; }

    public string PaymentSpeed { get; set; } = null!;

    public uint? CompanyId { get; set; }

    /// <summary>
    /// 0=inactive, 1=active, 2=pending, 3=rejected 
    /// </summary>
    public byte Status { get; set; }

    public uint? CreatedById { get; set; }

    public uint? UpdatedById { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
