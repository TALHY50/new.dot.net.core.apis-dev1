using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class DataType
{
    public uint Id { get; set; }

    public string Name { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public string DisplayNameSingular { get; set; } = null!;

    public string DisplayNamePlural { get; set; } = null!;

    public string? Icon { get; set; }

    public string? ModelName { get; set; }

    public string? PolicyName { get; set; }

    public string? Controller { get; set; }

    public string? Description { get; set; }

    public bool GeneratePermissions { get; set; }

    public sbyte ServerSide { get; set; }

    public string? Details { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<DataRow> DataRows { get; set; } = new List<DataRow>();
}
