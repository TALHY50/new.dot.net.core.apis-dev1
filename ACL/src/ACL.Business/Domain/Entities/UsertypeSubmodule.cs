using Ardalis.SharedKernel;

namespace ACL.Business.Domain.Entities;

public partial class UsertypeSubmodule : EntityBase<uint>, IAggregateRoot
{
    public byte UserTypeId { get; set; }

    public uint SubModuleId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
