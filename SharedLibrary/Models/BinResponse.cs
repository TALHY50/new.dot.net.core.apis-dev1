using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class BinResponse
{
    public int Id { get; set; }

    public string Bin { get; set; } = null!;

    public string Response { get; set; } = null!;

    public sbyte Attempt { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
