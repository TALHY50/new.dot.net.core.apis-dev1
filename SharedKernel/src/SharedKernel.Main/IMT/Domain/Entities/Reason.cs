namespace SharedKernel.Main.IMT.Domain.Entities;

public partial class Reason
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    /// <summary>
    /// 0 = inactive, 1=active, 2=soft=deleted
    /// </summary>
    public sbyte? Status { get; set; }

    public int? CreatedById { get; set; }

    public int? UpdatedById { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
