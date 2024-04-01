using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class MerchantVirtualAccountWalletCard
{
    public int Id { get; set; }

    /// <summary>
    /// merchant_virtual_account_wallets table primary id
    /// </summary>
    public int MerchantVirtualAccountWalletId { get; set; }

    /// <summary>
    /// masked card number from wallet gate
    /// </summary>
    public string CardReference { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
