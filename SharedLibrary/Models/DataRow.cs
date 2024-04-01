using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class DataRow
{
    public uint Id { get; set; }

    public uint DataTypeId { get; set; }

    public string Field { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string DisplayName { get; set; } = null!;

    public bool Required { get; set; }

    public bool? Browse { get; set; }

    public bool? Read { get; set; }

    public bool? Edit { get; set; }

    public bool? Add { get; set; }

    public bool? Delete { get; set; }

    public string? Details { get; set; }

    public int Order { get; set; }

    public virtual DataType DataType { get; set; } = null!;
}
