using Ardalis.SharedKernel;

namespace ACL.Business.Domain.Entities;

public partial class Country : EntityBase<ulong>, IAggregateRoot
{
    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Code { get; set; } = null!;

    public byte Status { get; set; }

    public ulong Sequence { get; set; }

    public ulong CreatedById { get; set; }

    public ulong UpdatedById { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
