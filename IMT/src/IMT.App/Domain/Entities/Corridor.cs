using System;
using System.Collections.Generic;

namespace IMT.App.Domain.Entities;

/// <summary>
/// Type : Master, corridor is setup of source country-currency to destination country-currency, like send GBP Euro to USA USD
/// </summary>
public partial class Corridor
{
    public uint Id { get; set; }

    public uint? SourceCountryId { get; set; }

    public uint? DestinationCountryId { get; set; }

    public uint? SourceCurrencyId { get; set; }

    public uint? DestinationCurrencyId { get; set; }

    public uint? CompanyId { get; set; }

    /// <summary>
    /// 0=inactive, 1=active, 2=pending, 3=rejected 
    /// </summary>
    public byte Status { get; set; }

    public uint? CreatedById { get; set; }

    public uint? UpdatedById { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
