using System;
using System.Collections.Generic;

namespace SharedLibrary.Models.IMT;

public partial class ImtPaymentMethod
{
    public int Id { get; set; }

    public string? MethodName { get; set; }

    public string? Description { get; set; }

    public int? CreatedById { get; set; }

    public int? UpdatedById { get; set; }

    /// <summary>
    /// must be soft delete, possible entries=&gt; wallet, debit card, credit card etc
    /// </summary>
    public sbyte? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
