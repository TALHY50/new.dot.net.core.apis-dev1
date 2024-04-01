using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class BankCot
{
    public int Id { get; set; }

    public int StaticBankId { get; set; }

    public string BankName { get; set; } = null!;

    public int CurrencyId { get; set; }

    /// <summary>
    /// 1=&gt;Withdrawal, 2=&gt;B2C to Bank
    /// </summary>
    public sbyte TransactionType { get; set; }

    public double Min { get; set; }

    public double Max { get; set; }

    public double SameBankCotPercentage { get; set; }

    public sbyte UserType { get; set; }

    public double SameBankCotFixed { get; set; }

    public double InterBankCotPercentage { get; set; }

    public double InterBankCotFixed { get; set; }

    public sbyte Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
