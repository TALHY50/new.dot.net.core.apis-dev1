using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class MerchantTransactionLimit
{
    public int Id { get; set; }

    public int MerchantId { get; set; }

    public int CurrencyId { get; set; }

    public sbyte PaymentTypeId { get; set; }

    /// <summary>
    /// 1=3D, 2 = 2D
    /// </summary>
    public sbyte TransactionType { get; set; }

    public double DailyMaxAmount { get; set; }

    public int DailyMaxNo { get; set; }

    public double MonthlyMaxAmount { get; set; }

    public int MonthlyMaxNo { get; set; }

    public double TransactionWiseMinAmount { get; set; }

    public double TransactionWiseMaxAmount { get; set; }

    public DateTime? DailyExpireDate { get; set; }

    public DateTime? MonthlyExpireDate { get; set; }

    public DateTime? TransactionWiseExpireDate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
