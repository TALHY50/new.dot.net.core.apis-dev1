using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class Translation
{
    public uint Id { get; set; }

    public string TableName { get; set; } = null!;

    public string ColumnName { get; set; } = null!;

    public uint ForeignKey { get; set; }

    public string Locale { get; set; } = null!;

    public string Value { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
