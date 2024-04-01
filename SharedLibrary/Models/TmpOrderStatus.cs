using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class TmpOrderStatus
{
    public int Id { get; set; }

    public string InvoiceId { get; set; } = null!;

    public string MerchantKey { get; set; } = null!;

    public string JsonResponse { get; set; } = null!;

    public DateTime? LastRequestedAt { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
