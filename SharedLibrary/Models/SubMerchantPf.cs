using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class SubMerchantPf
{
    public int Id { get; set; }

    public int MerchantId { get; set; }

    public string? PfId { get; set; }

    public string? Name { get; set; }

    public string? Vkn { get; set; }

    public string? Tckn { get; set; }

    public string? RemoteSubMerchantId { get; set; }

    public string? PostCode { get; set; }

    public string? City { get; set; }

    public string? Address { get; set; }

    public string? IsoCountryCode { get; set; }

    public string? Url { get; set; }

    public string? Mcc { get; set; }

    /// <summary>
    /// isbank,alternatifbank,halkbank
    /// </summary>
    public string? GroupId { get; set; }

    /// <summary>
    /// 0=&gt;inactive;1=&gt;active
    /// </summary>
    public sbyte Status { get; set; }

    /// <summary>
    /// 1=&gt;by Admin, 2=&gt; by Merchant, 3=&gt; by API 
    /// </summary>
    public sbyte Source { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
