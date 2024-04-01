using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class FraudRule
{
    public int Id { get; set; }

    public string RuleName { get; set; } = null!;

    /// <summary>
    /// 0 = General, 1 = Different Merchant Same Card, 2 = Same Merchant Same Card, 3 = Foreign Credit Card, 4 = Same Merchant, 5 = Different Merchant, 6 = Amount List, 7 = Same Merchant IP, 8 = Different Merchant IP, 9 = Same Card, 10 = Different Card, 11 = Risky Decline Codes, 12 = Rule on Existing Rules
    /// </summary>
    public sbyte RuleType { get; set; }

    public string? RuleDescription { get; set; }

    /// <summary>
    /// 0 = Please Select, 1 = All, 2 = Few, 3 = Except Few
    /// </summary>
    public sbyte? AssignMerchants { get; set; }

    /// <summary>
    /// all the merchant ids presented here as comma separated value
    /// </summary>
    public string? AssignMerchantsId { get; set; }

    /// <summary>
    /// 0 = Please Select, 1 = All, 2 = 2d, 3 = 3d
    /// </summary>
    public sbyte? TransactionType { get; set; }

    /// <summary>
    /// 0=Please Select,1=Any,2=Master Card,3=Visa Card,4=Amex,5=Diners,6=Discover,7=JCB
    /// </summary>
    public sbyte? CardType { get; set; }

    /// <summary>
    /// 4343xxxxx
    /// </summary>
    public string? CardTypeNoStartFrom { get; set; }

    /// <summary>
    /// 43234xxxx
    /// </summary>
    public string? CardTypeNoStartTo { get; set; }

    /// <summary>
    /// 0 = Please Select,1 = Greater Than,2 = Less Than,3 = Greater Than Or Equal,4 = Less Than Or Equal,5 = Equal,6 = Not Equal,7 = Range,
    /// </summary>
    public sbyte? TransactionAmount { get; set; }

    public int? TransactionAmountFrom { get; set; }

    public int? TransactionAmountTo { get; set; }

    /// <summary>
    /// 0 = Please Select,1 = IP White List,2 = Ip Black List,3 = Country White List,4 = Country Black List,
    /// </summary>
    public sbyte? IpCountryType { get; set; }

    /// <summary>
    /// All IP add as a comma separated value
    /// </summary>
    public string? IpCountryTypeList { get; set; }

    /// <summary>
    /// 0 = All,1 = Credit Card,2 = Debit Card,3 = Mobile Payment,4 = Wallet, Data add as a comma Separated value
    /// </summary>
    public string? PaymentMethod { get; set; }

    /// <summary>
    /// All currency add as a comma separated value
    /// </summary>
    public string? CurrencyId { get; set; }

    /// <summary>
    ///  0 = Please select, 1 = Approved, 2 = Approved but previously declined, 3 = declined
    /// </summary>
    public sbyte TransactionStateType { get; set; }

    public sbyte? ApprovedResponseCodeMinimumOccurrence { get; set; }

    /// <summary>
    /// All response code add as a comma separated value	
    /// </summary>
    public string? DeclinedResponseCode { get; set; }

    public sbyte? DeclinedResponseCodeMinimumOccurrence { get; set; }

    /// <summary>
    /// default=0,0=Not Active,1=Active
    /// </summary>
    public sbyte IsBinIpCountryActive { get; set; }

    /// <summary>
    /// 0 = Please Select,1 = Date and Time,2 = Date Only,3 = Time Only,4 = Today,5 = Last x Day,6 = Last x hour,
    /// </summary>
    public sbyte? TransactionPeriod { get; set; }

    /// <summary>
    /// 0 = Please Select,1 = Greater Than,2 = Less Than,3 = Greater Than Or Equal,4 = Less Than Or Equal,5 = Equal,6 = Not Equal,7 = Range,
    /// </summary>
    public sbyte? TransactionPeriodOperator { get; set; }

    public DateTime? TransactionPeriodDatetimeFrom { get; set; }

    public DateTime? TransactionPeriodDatetimeTo { get; set; }

    public DateOnly? TransactionPeriodDateFrom { get; set; }

    public DateOnly? TransactionPeriodDateTo { get; set; }

    public TimeOnly? TransactionPeriodTimeFrom { get; set; }

    public TimeOnly? TransactionPeriodTimeTo { get; set; }

    public string? TransactionPeriodXDays { get; set; }

    public string? TransactionPeriodXHours { get; set; }

    /// <summary>
    /// 0 = Please Select,1 = Greater Than,2 = Less Than,3 = Greater Than Or Equal,4 = Less Than Or Equal,5 = Equal,6 = Not Equal,7 = Range,
    /// </summary>
    public sbyte? TotalTransactionNumber { get; set; }

    public int? TotalTransactionNumberFrom { get; set; }

    public int? TotalTransactionNumberTo { get; set; }

    /// <summary>
    /// 0 = today, 1 = Last X days
    /// </summary>
    public sbyte? TotalTransactionNumberPeriod { get; set; }

    public int? TotalTransactionNumberNoOfDays { get; set; }

    /// <summary>
    /// 0 = Please Select,1 = Greater Than,2 = Less Than,3 = Greater Than Or Equal,4 = Less Than Or Equal,5 = Equal,6 = Not Equal,7 = Range,
    /// </summary>
    public sbyte? TotalTransactionAmount { get; set; }

    public int? TotalTransactionAmountFrom { get; set; }

    public int? TotalTransactionAmountTo { get; set; }

    /// <summary>
    /// 0 = today, 1 = Last X days
    /// </summary>
    public sbyte? TotalTransactionAmountPeriod { get; set; }

    public int? TotalTransactionAmountNoOfDays { get; set; }

    /// <summary>
    /// 0 = Please Select,1 = Low,2 = Medium,3 = High,
    /// </summary>
    public sbyte? Severity { get; set; }

    /// <summary>
    /// 1 - 100
    /// </summary>
    public sbyte? Score { get; set; }

    /// <summary>
    /// 0 = Please select,
    /// 1 = Domestic,
    /// 2 = Foreign
    /// </summary>
    public sbyte CardCategory { get; set; }

    /// <summary>
    /// 1 = Passive
    /// 2 = Active
    /// </summary>
    public sbyte RuleCategory { get; set; }

    /// <summary>
    /// Comma Separated Value
    /// </summary>
    public string? AmountLists { get; set; }

    /// <summary>
    /// 1=all, 2=ccredit card, 3= wallet, 4=mobile payment
    /// </summary>
    public sbyte RulePaymentType { get; set; }

    /// <summary>
    /// 0=Not Applied, 1=Applied
    /// </summary>
    public sbyte? IsFormulaApplied { get; set; }

    /// <summary>
    /// 0 = Disabled, 1 = Greater Than(&gt;), 2 = Less Than(&lt;), 3 = Greater Than Or Equal(&gt;=), 4 = Less Than Or Equal(&lt;=), 5 = Equal(=), 6 = Not Equal(!=)
    /// </summary>
    public sbyte? Revenue { get; set; }

    /// <summary>
    /// Percentage of revenue to compare
    /// </summary>
    public double? RevenuePercentage { get; set; }

    /// <summary>
    /// 1 =&gt; Last X Minute, 2 =&gt; Last X Hour, 3 =&gt; Last X Daily, 4 =&gt; Last X Monthly.
    /// </summary>
    public sbyte? RevenueDurationType { get; set; }

    /// <summary>
    /// Value of revenue duration
    /// </summary>
    public int? RevenueDurationValue { get; set; }

    public string? Formula { get; set; }

    /// <summary>
    /// 0=Not Active, 1=Active, 2=Inactive to waiting for approval, 3=Active to waiting for approval
    /// </summary>
    public sbyte? Status { get; set; }

    /// <summary>
    /// 1 = Email,
    /// 2 = SMS,
    /// 3 = Push Notification
    /// </summary>
    public string? NotificationType { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? CreatedById { get; set; }

    public int? ApprovedById { get; set; }

    public DateTime? ApprovedAt { get; set; }

    public int NumberOfDifferentCards { get; set; }

    /// <summary>
    /// Banned keywords in comma separated way
    /// </summary>
    public string? BannedKeywords { get; set; }
}
