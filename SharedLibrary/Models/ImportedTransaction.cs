using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class ImportedTransaction
{
    public int Id { get; set; }

    public int MerchantId { get; set; }

    public int MerchantTerminalsId { get; set; }

    public int? ImportedTransactionHistoryId { get; set; }

    public string InvoiceId { get; set; } = null!;

    /// <summary>
    ///  Remote(Pavo, Oxivo) Transaction Acquirer Reference 
    /// </summary>
    public string? RemoteAcquirerReference { get; set; }

    public string? Data { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// 0 =&gt; Pending, 1 =&gt; Completed, 2 =&gt; Failed, 3 =&gt; Refunded, 4 =&gt; Partial Refunded, 5 =&gt; Ignored, 6 =&gt; Exception.
    /// </summary>
    public sbyte? Status { get; set; }

    /// <summary>
    /// 1 =&gt; Oxivo, 2 =&gt; Pavo, 3 =&gt; Taxi, 4 =&gt; MT, 5 =&gt; WD, 6 =&gt; Hugin, 7 =&gt; Sari_Taxi
    /// </summary>
    public sbyte Type { get; set; }

    public sbyte? MigrationStatus { get; set; }

    /// <summary>
    /// Comment if necessary
    /// </summary>
    public string? Note { get; set; }

    /// <summary>
    /// Unique Order ID for every single Imported Transaction
    /// </summary>
    public string? OrderId { get; set; }

    /// <summary>
    ///  Remote(Pavo) Transaction Retrieval Reference Number
    /// </summary>
    public string? RemoteRrn { get; set; }

    /// <summary>
    ///  Remote(Pavo) Transaction Original Reference Number
    /// </summary>
    public string? RemoteOriginalReference { get; set; }

    /// <summary>
    /// Remote(Oxivo, Pavo, etc) Transaction State ID. Possible values are stored as constant value of model with prefix PAVO_REMOTE_STATE or OXIVO_REMOTE_STATE etc
    /// </summary>
    public sbyte? RemoteTransactionStateId { get; set; }
}
