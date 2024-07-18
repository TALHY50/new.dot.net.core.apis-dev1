namespace SharedKernel.Domain.IMT;

public partial class ImtProviderPayer
{
    public int Id { get; set; }

    public int ImtProviderId { get; set; }

    public int ImtCountryId { get; set; }

    public int ImtCurrencyId { get; set; }

    public int? ImtProviderServiceId { get; set; }

    public int? RemotePayerId { get; set; }

    /// <summary>
    /// for declaring precision point after decimal
    /// </summary>
    public sbyte? Precision { get; set; }

    /// <summary>
    /// still not clear, asked client
    /// </summary>
    public decimal? Increment { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
