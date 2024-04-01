using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class MerchantVirtualAccountWallet
{
    public int Id { get; set; }

    /// <summary>
    /// merchant_virtual_accounts table primary id
    /// </summary>
    public int MerchantVirtualAccountId { get; set; }

    /// <summary>
    /// merchant wallet number from wallet gate side
    /// </summary>
    public string WalletNumber { get; set; } = null!;

    /// <summary>
    /// currency table id
    /// </summary>
    public sbyte CurrencyId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
