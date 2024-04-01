using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class CronjobSetting
{
    public int Id { get; set; }

    /// <summary>
    /// signature of the cronjob
    /// </summary>
    public string Signature { get; set; } = null!;

    /// <summary>
    /// 0=user, 1=admin, 2=merchant, 3=ccpayment
    /// </summary>
    public sbyte? Panel { get; set; }

    /// <summary>
    /// 0=fixed time, 1=per minute, 2=per hour, 3=per day, 4=custom
    /// </summary>
    public sbyte? FrequencyType { get; set; }

    /// <summary>
    /// every frequency_value of minute/hour/day
    /// </summary>
    public string? FrequencyValue { get; set; }

    /// <summary>
    /// fixed run time for everyday
    /// </summary>
    public TimeOnly? RunTime { get; set; }

    /// <summary>
    /// next datetime to execute
    /// </summary>
    public DateTime? NextExecuteAt { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
