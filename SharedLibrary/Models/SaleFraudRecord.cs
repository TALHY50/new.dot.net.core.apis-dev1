using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class SaleFraudRecord
{
    public int Id { get; set; }

    /// <summary>
    /// id of sale_frauds
    /// </summary>
    public int SaleFraudId { get; set; }

    /// <summary>
    /// id of fraud_rules
    /// </summary>
    public int FraudRuleId { get; set; }

    /// <summary>
    /// 0 = Please Select, 1 = Low, 2 = Medium, 3 = High
    /// </summary>
    public int Severity { get; set; }

    /// <summary>
    /// 1 - 100
    /// </summary>
    public int Score { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
