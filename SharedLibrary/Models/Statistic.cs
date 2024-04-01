using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class Statistic
{
    public int Id { get; set; }

    /// <summary>
    /// 0=application block, 1=application enable
    /// </summary>
    public sbyte IsApplicationOnline { get; set; }

    public int CurrentNoOfFailedAttempt { get; set; }

    public int MaxNoOfFailedAttempt { get; set; }

    public string? MailAddresses { get; set; }

    public int? MaxCustomerNumber { get; set; }

    public string? Group { get; set; }

    public string? NewMerchantsEmailReceivers { get; set; }

    public string? UserWalletEmailReceivers { get; set; }

    public string? MonthlyB2cEmailReceivers { get; set; }

    public string? NewWithdrawalRequestEmailReceivers { get; set; }

    public string? TransactionSummaryEmailReceivers { get; set; }

    public string? NegativeRevenueEmailReceivers { get; set; }

    public string? NegativeBalanceEmailReceivers { get; set; }

    public int PosMaxFailedAttempt { get; set; }

    public string? PosFailedEmailAddresses { get; set; }

    public string? DailyBalanceReportReceivers { get; set; }

    public string? FirstTransactionAlert { get; set; }

    public string? KycVerificationIpWhiteList { get; set; }

    public string? TransactionStatusIpWhitelist { get; set; }

    public string? BinBlockToEmails { get; set; }

    public string? CashoutFileUploadedAlert { get; set; }

    public string? WithdrawalRequestCreated { get; set; }

    public string? AutomaticWithdrawalList { get; set; }

    public string? BrandServerIpList { get; set; }

    public string? CommissionReportEmail { get; set; }

    public string? AuditReportsReceiverMail { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? DailySentEmailCounter { get; set; }

    public DateTime? DailySentEmailDate { get; set; }

    public string? WalletGateReportEmailReceivers { get; set; }

    /// <summary>
    /// pos not found receicer email
    /// </summary>
    public string? RecurringPosNotificationEmail { get; set; }

    /// <summary>
    /// login session user email receivers
    /// </summary>
    public string? SessionUserEmail { get; set; }

    /// <summary>
    /// user blocked mail receivers 
    /// </summary>
    public string? BlockUserEmail { get; set; }

    /// <summary>
    /// merchant status change email receivers
    /// </summary>
    public string? MerchantStatusUpdateEmail { get; set; }

    /// <summary>
    /// Maker Checker Created, Approved, Rejected notification emails
    /// </summary>
    public string? MakerCheckerNotificationEmails { get; set; }

    /// <summary>
    /// Send notification email if user have no activity in panel for (n) days
    /// </summary>
    public string? InactivityNotificationEmail { get; set; }

    /// <summary>
    /// Send Email when a user change information
    /// </summary>
    public string? UserChangeInformationEmail { get; set; }

    public string? IncorrectLoginNotificationEmail { get; set; }

    /// <summary>
    /// User Max 5 Wrong Attempts Secret Question
    /// </summary>
    public string? UserWrongAttemptsSecretQuestionEmail { get; set; }

    /// <summary>
    /// send email of pavo transaction if it is a success and bank pos not found
    /// </summary>
    public string? PavoAlertEmails { get; set; }

    /// <summary>
    /// Test POS transaction failure notification receivers email
    /// </summary>
    public string? PosNotWorkingAlertReceivers { get; set; }

    /// <summary>
    /// Test POS default Merchant id 
    /// </summary>
    public int? PosNotWorkingMerchantId { get; set; }

    public string? FraudEmailReceivers { get; set; }

    /// <summary>
    /// List of btrans email receivers email_address in comma separately
    /// </summary>
    public string? BtransEmailReceivers { get; set; }

    /// <summary>
    /// allowed ip list for tenant server
    /// </summary>
    public string? TenantServerIps { get; set; }

    /// <summary>
    /// allowed ip list for finflow server
    /// </summary>
    public string? FinflowServerIps { get; set; }
}
