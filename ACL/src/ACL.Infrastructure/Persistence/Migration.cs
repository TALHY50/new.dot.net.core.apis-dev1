﻿namespace ACL.Infrastructure.Persistence;

public partial class Migration
{
    public uint Id { get; set; }

    public string Migration1 { get; set; } = null!;

    public int Batch { get; set; }
}
