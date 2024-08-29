namespace SharedBusiness.Main.IMT.Domain.Entities;

public partial class ProviderPayer
{
    public uint Id { get; set; }

    public uint ImtProviderId { get; set; }

    public uint ImtCountryId { get; set; }

    public uint ImtCurrencyId { get; set; }

    public uint? ImtProviderServiceId { get; set; }

    public uint? RemotePayerId { get; set; }

    public sbyte? Precision { get; set; }

    public decimal? Increment { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
