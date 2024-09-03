using Ardalis.SharedKernel;

namespace ACL.Business.Domain.Entities;

public partial class RolePage: EntityBase<ulong>, IAggregateRoot
{
    public ulong RoleId { get; set; }

    public ulong PageId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
