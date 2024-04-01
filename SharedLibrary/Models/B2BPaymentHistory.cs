using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class B2BPaymentHistory
{
    public uint Id { get; set; }

    public string? PaymentId { get; set; }

    public int SenderId { get; set; }

    public int ReceiverId { get; set; }

    public double Amount { get; set; }

    public string? Description { get; set; }

    public int? CurrencyId { get; set; }

    public int Status { get; set; }

    public int? SendId { get; set; }

    public int? ReceiveId { get; set; }

    public int? SendTransaction { get; set; }

    public int? ReceiveTransaction { get; set; }

    public string? Receipts { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? Name { get; set; }

    public string? GsmNumber { get; set; }

    public sbyte UserType { get; set; }

    /// <summary>
    /// 1-&gt; b2b, 2-&gt; b2u
    /// </summary>
    public sbyte? TransferType { get; set; }

    /// <summary>
    /// Authenticated user id
    /// </summary>
    public int ActionById { get; set; }
}
