namespace ACL.Core.Entities;

public partial class AclUsergroup
{
    public ulong Id { get; set; }

    public string GroupName { get; set; } = null!;

    /// <summary>
    /// 1 = Project manager, 2 = Developer, 3 = Reporter, 4 = Admin
    /// </summary>
    public sbyte Category { get; set; }

    public string? DashboardUrl { get; set; }

    public sbyte Status { get; set; }

    public ulong CompanyId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
