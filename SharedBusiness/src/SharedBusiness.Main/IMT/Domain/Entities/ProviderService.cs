namespace SharedBusiness.Main.IMT.Domain.Entities;

public partial class ProviderService
{
    public uint Id { get; set; }

    public uint ImtProviderId { get; set; }

    public string? Name { get; set; }

    public uint? CreatedById { get; set; }

    public uint? UpdatedById { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
