namespace SharedKernel.Main.ACL.Domain.Entities;

public partial class RolePage
{
    public ulong Id { get; set; }

    public ulong RoleId { get; set; }

    public ulong PageId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
