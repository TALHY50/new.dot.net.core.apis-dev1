using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class GovBtransPfRecord
{
    public int Id { get; set; }

    /// <summary>
    /// Referencable  id against type. Ex. sale id or withdrawal id or deposit id
    /// </summary>
    public int? ReferenceId { get; set; }

    /// <summary>
    /// 1 =&gt; Sale , 2 =&gt; Withdrawal, 3 =&gt; Deposit
    /// </summary>
    public sbyte? Type { get; set; }

    public string? BrandVkn { get; set; }

    public string? BrandFullCompanyName { get; set; }

    public string? PosBankName { get; set; }

    public string? BankIssuerDigit { get; set; }

    public string? BankTerminalId { get; set; }

    public string? PosAccountBankName { get; set; }

    public string? PosAccountBankCode { get; set; }

    public string? PosAccountBankIban { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
