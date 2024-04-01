using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class SaleWalletHistory
{
    public int Id { get; set; }

    public int SaleId { get; set; }

    public int UserId { get; set; }

    public int MerchantId { get; set; }

    public int CurrencyId { get; set; }

    public double WithdrawableAmount { get; set; }

    public double NonWithdrawableAmount { get; set; }

    public int TransactionStateId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
