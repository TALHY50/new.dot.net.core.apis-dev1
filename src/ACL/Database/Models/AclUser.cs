using System;
using System.Collections.Generic;

namespace ACL.Database.Models;

public partial class AclUser
{
    public ulong Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string Email { get; set; } = null!;

    public string? Avatar { get; set; }

    public string? Password { get; set; }

    public DateTime? Dob { get; set; }

    /// <summary>
    /// 1=Male, 2=Female
    /// </summary>
    public sbyte? Gender { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public uint Country { get; set; }

    public string? Phone { get; set; }

    /// <summary>
    /// 0=Pending, 1=Approved, 2=Not Approved, 3=Lock User
    /// </summary>
    public sbyte IsAdminVerified { get; set; }

    /// <summary>
    /// USER_TYPE_SS_ADMIN = 0; USER_TYPE_S_ADMIN = 1; USER_TYPE_USER = 2
    /// </summary>
    public uint UserType { get; set; }

    public string? RememberToken { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? ActivatedAt { get; set; }

    public string Language { get; set; } = null!;

    public string? Username { get; set; }

    public string? ImgPath { get; set; }

    /// <summary>
    /// 0=&gt;Inactive or disable; 1=&gt;enable or active; 2=&gt; disabled or suspected;3= awaiting disable or banned;4=awaiting GSM
    /// </summary>
    public sbyte Status { get; set; }

    public uint CompanyId { get; set; }

    public uint PermissionVersion { get; set; }

    /// <summary>
    /// 0 =&gt; all channel like sms, email, 1 =&gt; only sms, 2=&gt; only email
    /// </summary>
    public sbyte OtpChannel { get; set; }

    /// <summary>
    /// user logged in time
    /// </summary>
    public DateTime? LoginAt { get; set; }

    public uint CreatedById { get; set; }

    public string? AuthIdentifier { get; set; }
}
