﻿using Ardalis.SharedKernel;

namespace ACL.Business.Domain.Entities;

public partial class Page : EntityBase<uint>, IAggregateRoot
{
    public uint ModuleId { get; set; }

    public uint SubModuleId { get; set; }

    public string Name { get; set; } = null!;

    public string MethodName { get; set; } = null!;

    /// <summary>
    /// 1=Post, 2=Get, 3=Put, 4=Delete
    /// </summary>
    public int MethodType { get; set; }

    public sbyte AvailableToCompany { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
