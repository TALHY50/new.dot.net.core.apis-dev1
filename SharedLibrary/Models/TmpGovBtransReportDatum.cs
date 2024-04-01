using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class TmpGovBtransReportDatum
{
    public int Id { get; set; }

    public string? SaleData { get; set; }

    public string? SaleExtras { get; set; }

    public string? SaleObj { get; set; }

    public string? RefundHistoryObj { get; set; }

    public string? MerchantObj { get; set; }

    public string? WithdrawObj { get; set; }

    public string? B2cWalletObj { get; set; }

    public string? B2cBankObj { get; set; }

    public string? B2bObj { get; set; }

    public string? DepositObj { get; set; }

    /// <summary>
    /// 0 =&gt; Processed , 1 =&gt; Not Processed
    /// </summary>
    public sbyte? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// 1 =&gt; Sale , 2 =&gt; Refund, 3 =&gt; Deposit, 4 =&gt; B2C Bank, 5 =&gt; B2C Wallet, 6 =&gt; B2B&apos; after status
    /// </summary>
    public sbyte? Type { get; set; }

    /// <summary>
    /// Referenceable  id against type. Ex. sale id or withdrawal id or deposit id
    /// </summary>
    public int? ReferenceId { get; set; }
}
