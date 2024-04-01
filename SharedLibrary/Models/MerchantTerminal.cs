using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class MerchantTerminal
{
    public int Id { get; set; }

    public int MerchantId { get; set; }

    public string TerminalId { get; set; } = null!;

    /// <summary>
    /// 0 -&gt; In Active, 1 -&gt; Active 2 -&gt; Deleted
    /// </summary>
    public sbyte? Status { get; set; }

    /// <summary>
    /// 1 =&gt; Oxivo, 2 =&gt; Pavo
    /// </summary>
    public sbyte? Type { get; set; }

    /// <summary>
    /// IKS  terminal  Serial No
    /// </summary>
    public string? SerialNo { get; set; }

    /// <summary>
    /// IKS terminal Brand Code
    /// </summary>
    public string? BrandCode { get; set; }

    /// <summary>
    /// IKS  terminal  model name
    /// </summary>
    public string? Model { get; set; }

    /// <summary>
    /// IKS  terminal  status code
    /// </summary>
    public sbyte? StatusCode { get; set; }

    /// <summary>
    /// IKS  terminal Brand Sharing
    /// </summary>
    public string? BrandSharing { get; set; }

    /// <summary>
    /// 0=&gt;yes, 1=&gt; No
    /// </summary>
    public sbyte? PinPad { get; set; }

    /// <summary>
    /// 0: Only non with chip+magnetic, 1: Only contactless, 2: Chip+magnetic + contactless
    /// </summary>
    public sbyte? ContactLess { get; set; }

    /// <summary>
    /// A: ADSL, D: Dial-Up, E: Ethernet, G: GPRS, I: ISDN, S: GSM, W: Wi-Fi;
    /// </summary>
    public string? ConnectionType { get; set; }

    /// <summary>
    /// 0=&gt;not verified , 1=&gt;verfied
    /// </summary>
    public sbyte? IsIksVerified { get; set; }

    public string? VirtualPosUrl { get; set; }

    public string? HostingTaxNo { get; set; }

    public string? HostingTradeName { get; set; }

    public string? HostingUrl { get; set; }

    public string? PaymentGwTaxNo { get; set; }

    public string? PaymentGwTradeName { get; set; }

    public string? PaymentGwUrl { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
