using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class TestPosHistory
{
    public int Id { get; set; }

    public int? PosId { get; set; }

    public int? BankId { get; set; }

    public int? MerchantId { get; set; }

    /// <summary>
    /// 0 = failed, 1= success
    /// </summary>
    public bool? Status { get; set; }

    public string? BankResponseJson { get; set; }

    public string? BankErrorCode { get; set; }

    public string? BankErrorDescription { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
