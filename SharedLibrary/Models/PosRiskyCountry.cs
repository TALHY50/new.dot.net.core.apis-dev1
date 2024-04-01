using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class PosRiskyCountry
{
    public int Id { get; set; }

    public int PosId { get; set; }

    public string CountryCode { get; set; } = null!;

    public double ForeignRiskyCountryCcCotPercentage { get; set; }

    public double ForeignRiskyCountryCcCotFixed { get; set; }

    /// <summary>
    /// 0 = Inactive, 1 = Active
    /// </summary>
    public sbyte Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
