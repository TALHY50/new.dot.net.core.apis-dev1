using System;
using System.Collections.Generic;

namespace IMT.App.Domain.Entities;

public partial class TransactionType
{
    public uint Id { get; set; }

    public string? Name { get; set; }

    public byte? Status { get; set; }

    public uint? CreatedById { get; set; }

    public uint? UpdatedById { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
