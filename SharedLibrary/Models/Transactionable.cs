using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class Transactionable
{
    public uint Id { get; set; }

    public int UserId { get; set; }

    public int? RequestId { get; set; }

    public int? TransactionableId { get; set; }

    public string TransactionableType { get; set; } = null!;

    public string? PaymentId { get; set; }

    public int? EntityId { get; set; }

    public string? EntityName { get; set; }

    public string? ReasonTitle { get; set; }

    public int TransactionStateId { get; set; }

    public string Currency { get; set; } = null!;

    public string ActivityTitle { get; set; } = null!;

    public string MoneyFlow { get; set; } = null!;

    public double? Gross { get; set; }

    public double? Fee { get; set; }

    public double? Net { get; set; }

    public double? Balance { get; set; }

    public double? Cost { get; set; }

    public string? JsonData { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? CurrencyId { get; set; }

    public string? CurrencySymbol { get; set; }

    public string? NonSipayUserEmail { get; set; }

    public string? NonSipayUserPhone { get; set; }

    public sbyte? MigrationStatus { get; set; }

    public int? CreatedAtInt { get; set; }

    public int? UpdatedAtInt { get; set; }

    /// <summary>
    /// Authenticated user id
    /// </summary>
    public int ActionById { get; set; }
}
