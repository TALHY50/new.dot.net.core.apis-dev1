using Ardalis.SharedKernel;

namespace ACL.Business.Domain.Entities;

public partial class CompanyModule : EntityBase<ulong>, IAggregateRoot
{

    public ulong CompanyId { get; set; }

    public ulong ModuleId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
