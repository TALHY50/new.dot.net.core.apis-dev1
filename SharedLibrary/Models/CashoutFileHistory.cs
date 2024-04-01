using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class CashoutFileHistory
{
    public int Id { get; set; }

    public int MerchantId { get; set; }

    /// <summary>
    /// 1-&gt;cashout to bank;2-&gt;cashout to wallet
    /// </summary>
    public int Type { get; set; }

    public string FileName { get; set; } = null!;

    public string FileSize { get; set; } = null!;

    public int TotalRows { get; set; }

    public string FilePath { get; set; } = null!;

    /// <summary>
    /// 0=failed, 1= success
    /// </summary>
    public int Status { get; set; }

    /// <summary>
    /// 0=hide, 1= show 
    /// </summary>
    public sbyte FileShow { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
