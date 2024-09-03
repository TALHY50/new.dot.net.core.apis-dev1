namespace ACL.Business.Domain.Entities;

public partial class RolePage
{
    public uint Id { get; set; }

    public uint RoleId { get; set; }

    public uint PageId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
