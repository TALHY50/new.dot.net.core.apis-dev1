using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class MerchantEmailReceiver
{
    public int Id { get; set; }

    public int? MerchantId { get; set; }

    public string? Announcement { get; set; }

    public string? AvailableBalanceUpdate { get; set; }

    public string? MpSuccessAuthUser { get; set; }

    public sbyte MpSuccessUser { get; set; }

    public sbyte MpFailedUser { get; set; }

    public string? PaymentLinkSuccessAuthUser { get; set; }

    public sbyte PaymentLinkSuccessUser { get; set; }

    public sbyte PaymentLinkFailedUser { get; set; }

    public string? WebsiteIntegrationSuccessAuthUser { get; set; }

    public sbyte WebsiteIntegrationSuccessUser { get; set; }

    public sbyte WebsiteIntegrationFailedUser { get; set; }

    public string? FailedTransactionsInfo { get; set; }

    public string? CashoutToBankEmail { get; set; }

    public string? CashoutToWalletGateEmail { get; set; }

    public string? SupportTicketNotificationEmail { get; set; }

    public string? ChargebackRequestInfo { get; set; }

    public string? RefundNotification { get; set; }

    public string? AccountStatementReceipt { get; set; }

    public string? WithdrawalNotification { get; set; }

    public string? WithdrawalSuccessfulEmail { get; set; }

    public string? DepositNotification { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
