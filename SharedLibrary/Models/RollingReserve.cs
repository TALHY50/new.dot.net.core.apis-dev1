using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class RollingReserve
{
    public uint Id { get; set; }

    public int MerchantId { get; set; }

    public int CurrencyId { get; set; }

    public double? RollingReserveAmount { get; set; }

    public sbyte? SettlementType { get; set; }

    public sbyte? RollingStatus { get; set; }

    public sbyte? RollingReserveTimeLimit { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
