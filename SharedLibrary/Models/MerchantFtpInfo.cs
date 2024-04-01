using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class MerchantFtpInfo
{
    public int Id { get; set; }

    /// <summary>
    /// 1 =&gt; Daily account Statement
    /// </summary>
    public sbyte Type { get; set; }

    /// <summary>
    /// merchant primary id
    /// </summary>
    public int MerchantId { get; set; }

    /// <summary>
    /// merchant ftp host info
    /// </summary>
    public string Host { get; set; } = null!;

    /// <summary>
    /// merchant ftp username info
    /// </summary>
    public string Username { get; set; } = null!;

    /// <summary>
    /// merchant ftp password info
    /// </summary>
    public string Password { get; set; } = null!;

    /// <summary>
    /// merchant ftp port info
    /// </summary>
    public string Port { get; set; } = null!;

    /// <summary>
    /// merchant ftp root path info
    /// </summary>
    public string? RootPath { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
