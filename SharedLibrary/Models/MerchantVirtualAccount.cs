using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class MerchantVirtualAccount
{
    public int Id { get; set; }

    /// <summary>
    /// merchant table primary id
    /// </summary>
    public int MerchantId { get; set; }

    /// <summary>
    /// merchant account number from wallet gate side
    /// </summary>
    public string AccountNumber { get; set; } = null!;

    /// <summary>
    /// verification code form wallet gate side
    /// </summary>
    public sbyte? KycLevelCode { get; set; }

    /// <summary>
    /// encrypted national id of merchant while kyc verification
    /// </summary>
    public string? Tckn { get; set; }

    /// <summary>
    /// date of birth of merchant while kyc verification
    /// </summary>
    public DateOnly? Dob { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
