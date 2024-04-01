using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class MerchantPosPfSetting
{
    public int Id { get; set; }

    public int MerchantId { get; set; }

    public int PosId { get; set; }

    public string SubMerchantId { get; set; } = null!;

    /// <summary>
    /// &apos;1 = Send\r\n0 = Do not send\r\nFor some pos it determines whether we should send tckn vkn for some specific merchant&apos;;
    /// </summary>
    public bool? IsSendTcknVkn { get; set; }

    /// <summary>
    /// ( 1 = active, 0 = inactive) default 1
    /// </summary>
    public sbyte? Status { get; set; }

    public int? CreatedById { get; set; }

    public string? CreatedByName { get; set; }

    public int? UpdatedById { get; set; }

    public string? UpdatedByName { get; set; }

    /// <summary>
    /// 0 = Not From Migration;
    /// 1 = From Migration
    /// </summary>
    public sbyte MigrationStatus { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
