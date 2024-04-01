using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class City
{
    public uint Id { get; set; }

    public string Name { get; set; } = null!;

    public uint CountryId { get; set; }

    public string CountryCode { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
