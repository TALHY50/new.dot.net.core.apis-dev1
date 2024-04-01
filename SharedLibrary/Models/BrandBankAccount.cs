using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class BrandBankAccount
{
    public int Id { get; set; }

    public string? BankName { get; set; }

    public sbyte CurrencyId { get; set; }

    /// <summary>
    /// primary key of banks table
    /// </summary>
    public int StaticBankId { get; set; }

    public string? AccountHolderName { get; set; }

    public string? Iban { get; set; }

    public string? AccountNo { get; set; }

    public string? BranchCode { get; set; }

    /// <summary>
    /// Sipay Bank Account Branch Name
    /// </summary>
    public string? BranchName { get; set; }

    /// <summary>
    /// 1=&gt;active;0=&gt;inactive
    /// </summary>
    public sbyte Status { get; set; }

    /// <summary>
    /// 1=&gt;Deposit
    /// </summary>
    public sbyte AvailableFor { get; set; }

    /// <summary>
    /// 0=Not a sender bank, 1=Sender bank
    /// </summary>
    public sbyte IsSenderBank { get; set; }

    /// <summary>
    /// 0 = Not POS account, 1 = POS Account
    /// </summary>
    public bool? IsPosAccount { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// customer =&gt; 0, merchant =&gt; 2
    /// </summary>
    public sbyte? UserType { get; set; }
}
