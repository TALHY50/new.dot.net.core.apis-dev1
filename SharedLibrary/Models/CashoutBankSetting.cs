using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class CashoutBankSetting
{
    public int Id { get; set; }

    /// <summary>
    /// 1=User withdrawal, 2=Merchant withdrawal, 3=B2C cashout to bank
    /// </summary>
    public sbyte Code { get; set; }

    /// <summary>
    /// 1=TRY, 2=USD, 3=EUR
    /// </summary>
    public sbyte CurrencyId { get; set; }

    public int? BankId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
