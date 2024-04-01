using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class UserProfile
{
    public int Id { get; set; }

    public int UserId { get; set; }

    /// <summary>
    /// 0=disabled; 1=enabled
    /// </summary>
    public sbyte EnableMoneyTransfer { get; set; }

    /// <summary>
    /// 0 -&gt; not_verifed;1 -&gt; verifed;
    /// </summary>
    public bool IsFaceToFaceVerified { get; set; }

    /// <summary>
    /// 0=&gt;No; 1=&gt;Yes;
    /// </summary>
    public bool? IsMoneyTransferMaxExceed { get; set; }

    /// <summary>
    /// 0=&gt;No; 1=&gt;Yes;
    /// </summary>
    public bool? MoneyTransferFromTotalBalance { get; set; }

    public sbyte? NumberOfAllowedCreditCard { get; set; }

    /// <summary>
    /// 1=yes, 0=no
    /// </summary>
    public bool? IsShowBalance { get; set; }

    public sbyte IsShowRecentActivities { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// date of kyc completed by user
    /// </summary>
    public DateTime? KycUpdatedAt { get; set; }

    /// <summary>
    /// other sector name
    /// </summary>
    public string? OtherSector { get; set; }

    /// <summary>
    /// 1=active; 2=suspected; 3=banned
    /// </summary>
    public sbyte? Status { get; set; }

    public string? ActivationCode { get; set; }

    public sbyte? IsIntegrationCalled { get; set; }

    public sbyte? ActivationCodeCount { get; set; }

    public sbyte? ActivationWrongAttempt { get; set; }

    public string? ActivationStatusCode { get; set; }

    public string? ActivationStatusDescription { get; set; }

    public string? ActivationRemoteReferenceId { get; set; }

    public DateTime? ActivationCodeUpdatedAt { get; set; }

    /// <summary>
    /// when a user change information here it will be count
    /// </summary>
    public int? InfoChangeCount { get; set; }

    /// <summary>
    /// 1 =&gt; Email Sent, 0 =&gt; Email Not Sent Yet
    /// </summary>
    public bool? IsWelcomeEmailSent { get; set; }

    /// <summary>
    /// user income info
    /// </summary>
    public double? IncomeInfo { get; set; }

    /// <summary>
    /// User can&apos;t update income info more than three time&apos;s for yemekpay
    /// </summary>
    public sbyte? NumberOfIncomeModification { get; set; }

    public const int  DISABLED = 0;
    public const int  ENABLED = 1;
    public const int  ACTIVE = 1;
    public const int  BANNED = 3;
    public const int  SUSPECTED = 2;
    public const int  INACTIVE = 4;
    public const int  FACE_TO_FACE_VERIFIED = 1;
    public const int  FACE_TO_FACE_NOT_VERIFIED = 0;
    public const int  IS_MONEY_TRANSFER_MAX_EXCEED_YES = 1;
    public const int  IS_MONEY_TRANSFER_MAX_EXCEED_NO = 0;
    public const int  MONEY_TRANSFER_FROM_TOTAL_BALANCE_YES = 1;
    public const int  MONEY_TRANSFER_FROM_TOTAL_BALANCE_NO = 0;
}
