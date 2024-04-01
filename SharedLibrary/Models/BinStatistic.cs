using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class BinStatistic
{
    public int Id { get; set; }

    public string? Bin { get; set; }

    public string? BrandCode { get; set; }

    /// <summary>
    /// cg=craft_gate, mu=msu
    /// </summary>
    public string? DestinationApi { get; set; }

    public string? Response { get; set; }

    public DateTime? CreatedAt { get; set; }
    public const string CRAFT_GATE = "cg";
    public const string MSU = "mu";
}
