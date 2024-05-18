namespace ACL.Core.Models;

public partial class AclRole
{
    public ulong Id { get; set; }

    public string? Title { get; set; }

    public string? Name { get; set; }

    public sbyte Status { get; set; }

    public ulong CompanyId { get; set; }

    /// <summary>
    /// creator auth ID
    /// </summary>
    public ulong? CreatedById { get; set; }

    /// <summary>
    /// approve auth ID
    /// </summary>
    public ulong? UpdatedById { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
