using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class BinDetail
{
    public int Id { get; set; }

    public int? BinNumber { get; set; }

    public string? BrandName { get; set; }

    public string? CardType { get; set; }

    public string? IssuerBank { get; set; }

    public string? CountryCode { get; set; }
}
