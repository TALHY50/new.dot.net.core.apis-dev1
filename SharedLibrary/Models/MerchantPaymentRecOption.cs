using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class MerchantPaymentRecOption
{
    public ulong Id { get; set; }

    public int MerchantId { get; set; }

    public sbyte PaymentRecOptionId { get; set; }

    public sbyte Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
