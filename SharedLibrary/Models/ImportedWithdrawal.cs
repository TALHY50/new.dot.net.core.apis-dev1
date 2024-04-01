using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class ImportedWithdrawal
{
    public int Id { get; set; }

    /// <summary>
    /// withdrawals table unique id for destination type 7
    /// </summary>
    public string UniqueId { get; set; } = null!;

    /// <summary>
    /// withdrawal amount
    /// </summary>
    public double Amount { get; set; }

    /// <summary>
    /// withdrawal currency id
    /// </summary>
    public sbyte CurrencyId { get; set; }

    /// <summary>
    /// 99 = withdrawal approve , rest of them withdrawal reject
    /// </summary>
    public sbyte RemoteWithdrawalState { get; set; }

    /// <summary>
    /// withdrawal file data in json format
    /// </summary>
    public string Data { get; set; } = null!;

    /// <summary>
    /// 0 = pending , 1 = processed, 2 = failed , 3 = uncounted withdrawal, 4 = error exception
    /// </summary>
    public sbyte Status { get; set; }

    /// <summary>
    /// Comment if necessary
    /// </summary>
    public string? Note { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// 0=not yet; 2=reverted
    /// </summary>
    public sbyte? RevertedStatus { get; set; }

    /// <summary>
    /// 0=nothing; id from tmp_files table
    /// </summary>
    public int? TmpFileId { get; set; }
}
