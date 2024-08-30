namespace SharedBusiness.Main.Common.Domain.Entities;

public partial class Country
{
    public uint Id { get; set; }

    public string? IsoCodeShort { get; set; }

    public string? IsoCode { get; set; }
    
    public string? IsoCodeNum { get; set; }

    public string? Name { get; set; }
    
    public string? OfficialStateName { get; set; }

    public uint? CreatedById { get; set; }

    public uint? UpdatedById { get; set; }

    /// <summary>
    /// 1=active, 0=inactive, 2=soft-deleted
    /// </summary>
    public int? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
