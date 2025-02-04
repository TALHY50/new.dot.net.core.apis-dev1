﻿using Ardalis.SharedKernel;

namespace ACL.Business.Domain.Entities;

public partial class CompanyModule : EntityBase<uint>, IAggregateRoot
{

    public uint CompanyId { get; set; }

    public uint ModuleId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
