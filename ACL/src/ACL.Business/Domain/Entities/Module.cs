using Ardalis.SharedKernel;

namespace ACL.Business.Domain.Entities;

public partial class Module : EntityBase<uint>, IAggregateRoot
{

    public string Name { get; set; } = null!;

    public string Icon { get; set; } = null!;

    public int Sequence { get; set; }

    public string DisplayName { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
