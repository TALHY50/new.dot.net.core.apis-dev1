namespace SharedBusiness.Main.Common.Domain.Entities;

public partial class Reason
{
    public uint Id { get; set; }

    public string? Code { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    /// <summary>
    /// 0 = inactive, 1=active, 2=soft=deleted
    /// </summary>
    public byte? Status { get; set; }

    public uint? CreatedById { get; set; }

    public uint? UpdatedById { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
