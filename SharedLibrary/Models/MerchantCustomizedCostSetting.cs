using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class MerchantCustomizedCostSetting
{
    public int Id { get; set; }

    /// <summary>
    /// currency Id
    /// </summary>
    public sbyte CurrencyId { get; set; }

    /// <summary>
    ///  Receiver name
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// gsm for Receiver 
    /// </summary>
    public string ReceiverGsm { get; set; } = null!;

    /// <summary>
    /// iban  for Receiver 
    /// </summary>
    public string ReceiverIban { get; set; } = null!;

    /// <summary>
    /// bank id for approve
    /// </summary>
    public int FromBankId { get; set; }

    /// <summary>
    /// 1 = b2c cashout process , 2 = process imported withdrawal 
    /// </summary>
    public sbyte Type { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
