namespace SharedBusiness.Main.IMT.Domain.Entities;

public partial class Country
{
    public uint Id { get; set; }

    public string? Code { get; set; }

    public string? IsoCode { get; set; }

    public string? Name { get; set; }

    public uint? CreatedById { get; set; }

    public uint? UpdatedById { get; set; }

    /// <summary>
    /// 1=active, 0=inactive, 2=soft-deleted
    /// </summary>
    public byte? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
