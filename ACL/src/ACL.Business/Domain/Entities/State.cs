﻿using Ardalis.SharedKernel;

namespace ACL.Business.Domain.Entities;

public partial class State : EntityBase<uint>, IAggregateRoot
{
    public uint CountryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; } = null!;

    public byte Status { get; set; }

    public uint Sequence { get; set; }

    public uint CreatedById { get; set; }

    public uint UpdatedById { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
