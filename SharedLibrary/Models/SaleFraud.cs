using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class SaleFraud
{
    public int Id { get; set; }

    public int? SaleId { get; set; }

    /// <summary>
    /// 1=completed, 2=rejected, 3=pending
    /// </summary>
    public sbyte? Status { get; set; }

    public int? ApprovedById { get; set; }

    public string? ApprovedByName { get; set; }

    /// <summary>
    /// Single score , or multiple score by adding
    /// </summary>
    public double? Score { get; set; }

    public double Severity { get; set; }

    /// <summary>
    /// Single role name , or multiple rule name by comma separator
    /// </summary>
    public string? RuleName { get; set; }

    public sbyte? PaymentTypeId { get; set; }

    public string? Comment { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? AapprovedDatetime { get; set; }

    /// <summary>
    /// format: rule_name - rule_description
    /// </summary>
    public string? Remarks { get; set; }
}
