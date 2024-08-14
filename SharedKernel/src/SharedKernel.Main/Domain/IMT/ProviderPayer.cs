namespace SharedKernel.Main.Domain.IMT;

public partial class ProviderPayer
{
    public ulong Id { get; set; }

    public ulong ImtProviderId { get; set; }

    public ulong ImtCountryId { get; set; }

    public ulong ImtCurrencyId { get; set; }

    public ulong? ImtProviderServiceId { get; set; }

    public ulong? RemotePayerId { get; set; }

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
