using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class PaybillOption
{
    public int Id { get; set; }

    public string? BillPaymentProvider { get; set; }

    public string? Credentials { get; set; }

    /// <summary>
    /// Url for get category
    /// </summary>
    public string? CategoryUrl { get; set; }

    /// <summary>
    /// Url for get sub category
    /// </summary>
    public string? SubCategoryUrl { get; set; }

    /// <summary>
    /// Url for get invoices
    /// </summary>
    public string? InvoiceUrl { get; set; }

    /// <summary>
    /// Url for pay invoce or bill payment
    /// </summary>
    public string? PaymentUrl { get; set; }

    /// <summary>
    /// Url for cancel bill payment
    /// </summary>
    public string? CancelUrl { get; set; }

    /// <summary>
    /// 1=&gt; active, 0=&gt;inactive
    /// </summary>
    public sbyte Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
