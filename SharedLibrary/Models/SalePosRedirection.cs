using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class SalePosRedirection
{
    /// <summary>
    /// N/A
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// N/A
    /// </summary>
    public int SaleId { get; set; }

    /// <summary>
    /// N/A
    /// </summary>
    public int FromPosId { get; set; }

    /// <summary>
    /// N/A
    /// </summary>
    public int ToPosId { get; set; }

    public string OrderId { get; set; } = null!;

    public int MerchantId { get; set; }

    /// <summary>
    /// N/A
    /// </summary>
    public DateTime? CreatedAt { get; set; }
}
