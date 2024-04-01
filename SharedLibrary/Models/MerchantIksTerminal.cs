using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class MerchantIksTerminal
{
    public int Id { get; set; }

    public int? MerchantIksId { get; set; }

    public int? GlobalMerchantId { get; set; }

    public int? PspMerchantId { get; set; }

    public string? TerminalId { get; set; }

    public string? StatusCode { get; set; }

    public string? Type { get; set; }

    public string? BrandCode { get; set; }

    public string? Model { get; set; }

    public string? SerialNo { get; set; }

    public int? OwnerPspNo { get; set; }

    public string? OwnerTerminalId { get; set; }

    public string? BrandSharing { get; set; }

    public string? PinPad { get; set; }

    public string? ContactLess { get; set; }

    public string? ConnectionType { get; set; }

    public string? VirtualPosUrl { get; set; }

    public string? HostingTaxNo { get; set; }

    public string? HostingTradeName { get; set; }

    public string? HostingUrl { get; set; }

    public string? PaymentGwTaxNo { get; set; }

    public string? PaymentGwTradeName { get; set; }

    public string? PaymentGwUrl { get; set; }

    public int? ServiceProviderPspNo { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
