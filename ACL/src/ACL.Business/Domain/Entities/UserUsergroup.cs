using Ardalis.SharedKernel;

namespace ACL.Business.Domain.Entities;

public partial class UserUsergroup : EntityBase<uint>, IAggregateRoot
{
    public uint UsergroupId { get; set; }

    public uint UserId { get; set; }

    public uint CompanyId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
