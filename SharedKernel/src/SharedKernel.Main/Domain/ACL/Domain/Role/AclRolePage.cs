namespace SharedKernel.Main.Domain.ACL.Domain.Role;

public partial class AclRolePage
{
    public ulong Id { get; set; }

    public ulong RoleId { get; set; }

    public ulong PageId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
