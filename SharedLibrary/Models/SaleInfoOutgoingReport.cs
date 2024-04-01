using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class SaleInfoOutgoingReport
{
    public int Id { get; set; }

    /// <summary>
    /// sales table id
    /// </summary>
    public int? SaleId { get; set; }

    /// <summary>
    /// sales table order_id
    /// </summary>
    public string? OrderId { get; set; }

    /// <summary>
    /// sale info should be stored as json
    /// </summary>
    public string? SaleInfo { get; set; }

    /// <summary>
    /// when we found any exception to connect with another database
    /// </summary>
    public string? Exception { get; set; }

    public DateTime? CreatedAt { get; set; }
}
