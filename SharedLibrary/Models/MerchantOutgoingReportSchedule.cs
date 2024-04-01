using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class MerchantOutgoingReportSchedule
{
    public int Id { get; set; }

    /// <summary>
    /// id from merchant table
    /// </summary>
    public int MerchantId { get; set; }

    /// <summary>
    /// id from settlement table, it can be daily , monthly etc
    /// </summary>
    public int SettlementId { get; set; }

    /// <summary>
    /// 1=ftp,2=dropbox,3=email
    /// </summary>
    public int DestinationType { get; set; }

    /// <summary>
    /// Information about destination type like email,ftp, dropbox
    /// </summary>
    public string? Credentials { get; set; }

    /// <summary>
    /// 1=Migros
    /// </summary>
    public sbyte ReportType { get; set; }

    /// <summary>
    /// when the report should be exported
    /// </summary>
    public DateTime NextEffectiveDate { get; set; }

    /// <summary>
    /// Auth id who created it 
    /// </summary>
    public int CreatedById { get; set; }

    /// <summary>
    /// Auth id who updated the existing data
    /// </summary>
    public int? UpdatedById { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
