using Ardalis.SharedKernel;

namespace ACL.Business.Domain.Entities;

public partial class UsergroupRole : EntityBase<uint>, IAggregateRoot
{
    public uint UsergroupId { get; set; }

    public uint RoleId { get; set; }

    public uint CompanyId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
