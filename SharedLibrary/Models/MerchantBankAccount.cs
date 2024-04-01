using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class MerchantBankAccount
{
    public int Id { get; set; }

    public int MerchantId { get; set; }

    public sbyte CurrencyId { get; set; }

    public string BankName { get; set; } = null!;

    /// <summary>
    /// primary key of banks table
    /// </summary>
    public int StaticBankId { get; set; }

    public string AccountHolderName { get; set; } = null!;

    public string? Iban { get; set; }

    public string? AccountNo { get; set; }

    public string? BranchCode { get; set; }

    public string? BranchName { get; set; }

    public string? SwiftCode { get; set; }

    public sbyte Status { get; set; }

    public int CountryId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
