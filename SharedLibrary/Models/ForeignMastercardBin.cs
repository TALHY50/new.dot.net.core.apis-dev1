using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class ForeignMastercardBin
{
    public int Id { get; set; }

    public string CompanyName { get; set; } = null!;

    public string Ica { get; set; } = null!;

    public long AccountRangeFrom { get; set; }

    public long AccountRangeTo { get; set; }

    public string BrandProductCode { get; set; } = null!;

    public string BrandProductName { get; set; } = null!;

    public string AcceptanceBrand { get; set; } = null!;

    public string Country { get; set; } = null!;
}
