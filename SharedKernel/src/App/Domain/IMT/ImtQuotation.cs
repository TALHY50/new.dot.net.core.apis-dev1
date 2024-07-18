namespace App.Domain.IMT;

public partial class ImtQuotation
{
    public int Id { get; set; }

    public string OrderId { get; set; } = null!;

    public string PayerId { get; set; } = null!;

    /// <summary>
    /// DESTINATION_AMOUNT, SOURCE_AMOUNT
    /// </summary>
    public string Mode { get; set; } = null!;

    /// <summary>
    /// B2B,B2C,C2C,C2B
    /// </summary>
    public string TransactionType { get; set; } = null!;

    public decimal? SourceAmount { get; set; }

    public int? ImtSourceCurrencyId { get; set; }

    public int? ImtProviderId { get; set; }

    public int? ImtProviderServiceId { get; set; }

    public int? ImtSourceCountryId { get; set; }

    public decimal? DestinationAmount { get; set; }

    public int? ImtDestinationCurrencyId { get; set; }

    public DateTime? CreatedAt { get; set; }
}
