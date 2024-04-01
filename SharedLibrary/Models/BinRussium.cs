using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class BinRussium
{
    public int Id { get; set; }

    public int? BinFrom { get; set; }

    public int? BinTo { get; set; }

    public string? BrandName { get; set; }

    public string? CardType { get; set; }

    public string? IssuerName { get; set; }

    public string ActualIssuerName { get; set; } = null!;

    public string? CountryCode { get; set; }
}
