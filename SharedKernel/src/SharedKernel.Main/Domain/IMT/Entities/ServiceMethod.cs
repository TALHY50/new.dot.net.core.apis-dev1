using System;
using System.Collections.Generic;

namespace SharedKernel.Main.Domain.IMT.Entities;

/// <summary>
/// Type : Master, delivery methods of transactions
/// </summary>
public partial class ServiceMethod
{
    public uint Id { get; set; }

    /// <summary>
    /// 1 = Bank Account, 2 = Wallet, 3 = Cash Pickup, 4 = Card
    /// </summary>
    public byte Method { get; set; }

    public uint? CompanyId { get; set; }

    /// <summary>
    /// 0=inactive, 1=active, 2=pending, 3=rejected 
    /// </summary>
    public byte Status { get; set; }

    public uint? CreatedById { get; set; }

    public uint? UpdatedById { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
