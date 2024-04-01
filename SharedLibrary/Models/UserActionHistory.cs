using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class UserActionHistory
{
    public int Id { get; set; }

    public int UserId { get; set; }

    /// <summary>
    /// 0=&gt;customer; 1=&gt;admin; 2=&gt;merchant; 3=&gt;submerchant
    /// </summary>
    public int? UserType { get; set; }

    /// <summary>
    /// 1=&gt;Banned, 2=&gt;Blocked, 3=&gt;Failed Login, user Action History
    /// </summary>
    public sbyte Type { get; set; }

    /// <summary>
    /// process by using on maker checker
    /// </summary>
    public int? ProcessedBy { get; set; }

    /// <summary>
    /// Approve by using on maker checker
    /// </summary>
    public int? ApprovedBy { get; set; }

    /// <summary>
    /// 0=&gt;awaiting, 1=&gt;approved
    /// </summary>
    public sbyte Status { get; set; }

    /// <summary>
    /// user first name and last name
    /// </summary>
    public string? UserName { get; set; }

    /// <summary>
    /// user email
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// user gsm 
    /// </summary>
    public string? Gsm { get; set; }

    /// <summary>
    /// 0 =&gt; Defult
    /// 1 =&gt; USER_UPDATE
    /// 2 =&gt; ROLE_UPDATE
    /// 3 =&gt; USERGROUP_UPDATE
    /// 4 =&gt; USERGROUP_ROLE_ASSOCIATION_UPDATE
    /// 5 =&gt; ROLE_PAGE_ASSOCIATION_UPDATE
    /// </summary>
    public sbyte ActionId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
