namespace SharedKernel.Domain.IMT;

public partial class ImtReason
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    /// <summary>
    /// default value 0 means &quot;Others&quot;
    /// </summary>
    public sbyte? Status { get; set; }

    public int? CreatedById { get; set; }

    public int? UpdatedById { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
