namespace SharedKernel.Main.IMT.Domain.Entities;

public partial class ProviderPayer
{
    public int Id { get; set; }

    public int ImtProviderId { get; set; }

    public int ImtCountryId { get; set; }

    public int ImtCurrencyId { get; set; }

    public int? ImtProviderServiceId { get; set; }

    public int? RemotePayerId { get; set; }

    public sbyte? Precision { get; set; }

    public decimal? Increment { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
