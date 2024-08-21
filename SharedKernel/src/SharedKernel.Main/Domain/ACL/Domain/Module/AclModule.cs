namespace SharedKernel.Main.Domain.ACL.Domain.Module;

public partial class AclModule
{
    public ulong Id { get; set; }

    public string Name { get; set; } = null!;

    public string Icon { get; set; } = null!;

    public int Sequence { get; set; }

    public string DisplayName { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
