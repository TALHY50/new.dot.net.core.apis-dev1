using Ardalis.SharedKernel;

namespace ACL.Business.Domain.Entities;

public partial class RolePage: EntityBase<uint>, IAggregateRoot
{
    public uint RoleId { get; set; }

    public uint PageId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
