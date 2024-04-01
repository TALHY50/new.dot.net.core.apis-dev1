using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class Voucher
{
    public uint Id { get; set; }

    public int? UserId { get; set; }

    public double VoucherAmount { get; set; }

    public string VoucherCode { get; set; } = null!;

    public string? JsonData { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? CurrencyId { get; set; }

    public string? CurrencySymbol { get; set; }

    public int? UserLoader { get; set; }

    public sbyte? IsLoaded { get; set; }

    public double? VoucherFee { get; set; }

    public int? WalletId { get; set; }

    public double? VoucherValue { get; set; }
}
