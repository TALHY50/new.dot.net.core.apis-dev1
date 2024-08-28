namespace ACL.App.Domain.Entities;

public partial class SubModule
{
    public ulong Id { get; set; }

    public ulong ModuleId { get; set; }

    public string Name { get; set; } = null!;

    public string ControllerName { get; set; } = null!;

    public string Icon { get; set; } = null!;

    public int Sequence { get; set; }

    public string DefaultMethod { get; set; } = null!;

    public string DisplayName { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
