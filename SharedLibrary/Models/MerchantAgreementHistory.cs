using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class MerchantAgreementHistory
{
    public int Id { get; set; }

    public int? MerchantId { get; set; }

    public int? MerchantAgreementId { get; set; }

    public DateTime? AcceptedRejectedDatetime { get; set; }

    public int? AcceptedByUserId { get; set; }

    public string? AcceptedByUserName { get; set; }

    /// <summary>
    /// 0 = uploaded and approved by merchant, 1 = approved physically  by admin
    /// </summary>
    public sbyte? ApprovedSource { get; set; }

    /// <summary>
    /// file path of physically approved agreement
    /// </summary>
    public string? FilePath { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
