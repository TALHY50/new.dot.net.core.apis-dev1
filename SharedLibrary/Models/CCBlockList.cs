using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class CCBlockList
{
    public int Id { get; set; }

    public string? CardHolderName { get; set; }

    public string? CardNo { get; set; }

    public int? BlockerId { get; set; }

    public string? BlockerEmail { get; set; }

    public string? BlockerName { get; set; }

    public string? BlockReason { get; set; }

    public int? EditorId { get; set; }

    public string? EditorEmail { get; set; }

    public string? EditorName { get; set; }

    /// <summary>
    /// 1=blocked, 2=unblocked, 3=pending from unblocked to block, 4=pending from blocked to unblock
    /// </summary>
    public sbyte? Status { get; set; }

    public DateTime? BlockedFrom { get; set; }

    public DateTime? BlockedTo { get; set; }

    /// <summary>
    /// 1=card, 2=bin, 3=full card
    /// </summary>
    public sbyte? Type { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// 0=forever, 1=temporary
    /// </summary>
    public sbyte? IsBlockTemporarily { get; set; }

    public sbyte? MigrationStatus { get; set; }

    /// <summary>
    /// 0=All merchant
    /// </summary>
    public int MerchantId { get; set; }

    public const int BLOCKED = 1;
    public const int UNBLOCKED = 2;
    public const int UNBLOCKED_TO_BLOCK = 3;
    public const int BLOCKED_TO_UNBLOCK = 4;
    public const int TYPE_CARD = 1;
    public const int TYPE_BIN = 2;
    public const int TYPE_FULL_CARD = 3;
    public const int APPROVE = 1;
    public const int REJECT = 2;
}
