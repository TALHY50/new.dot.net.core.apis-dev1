using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class TmpWixForm
{
    public int Id { get; set; }

    public string MerchantId { get; set; } = null!;

    public string KeyName { get; set; } = null!;

    public string FormObj { get; set; } = null!;

    public string InvoiceId { get; set; } = null!;

    public string OrderId { get; set; } = null!;

    public string? WixRefundId { get; set; }

    public sbyte Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
