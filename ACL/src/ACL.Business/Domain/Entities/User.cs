using System.ComponentModel.DataAnnotations.Schema;
using Ardalis.SharedKernel;
using Microsoft.AspNetCore.Identity;
using SharedKernel.Main.Domain;

namespace ACL.Business.Domain.Entities;

public partial class User : IdentityUserEntityBase<uint>, IAggregateRoot
{
   
    public string? FirstName { get; set; }
    
    public string? LastName { get; set; }
    //[NotMapped]
    //public string Email { get; set; } = null!;
    
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
    /// [NotMapped]
    
    public sbyte IsAdminVerified { get; set; }

    /// <summary>
    /// USER_TYPE_SS_ADMIN = 0; USER_TYPE_S_ADMIN = 1; USER_TYPE_USER = 2
    /// </summary>
    [NotMapped]
    public uint UserType { get; set; }

    [NotMapped]
    public string? RememberToken { get; set; }

    [NotMapped]
    public RefreshToken RefreshToken { get; set; }

    [NotMapped]
    public string? Salt { get; set; }

    [NotMapped]
    public DateTime? CreatedAt { get; set; }

    [NotMapped]
    public DateTime? UpdatedAt { get; set; }
    
    public DateTime? ActivatedAt { get; set; }

    [NotMapped]
    public string Language { get; set; } = null!;

   // [NotMapped]
//    public string? UserName { get; set; }

    [NotMapped]
    public string? ImgPath { get; set; }

    //public IList<Claim> Claims { get; set; }

    /// <summary>
    /// 0=&gt;Inactive or disable; 1=&gt;enable or active; 2=&gt; disabled or suspected;3= awaiting disable or banned;4=awaiting GSM
    /// </summary>
    
    [NotMapped]
    public sbyte Status { get; set; }

    [NotMapped]
    public uint CompanyId { get; set; }

    [NotMapped]
    public uint PermissionVersion { get; set; }

    /// <summary>
    /// 0 =&gt; all channel like sms, email, 1 =&gt; only sms, 2=&gt; only email
    /// </summary>
    [NotMapped]
    public sbyte OtpChannel { get; set; }

    /// <summary>
    /// user logged in time
    /// </summary>
    [NotMapped]
    public DateTime? LoginAt { get; set; }

    [NotMapped]
    public uint CreatedById { get; set; }

    [NotMapped]
    public string? AuthIdentifier { get; set; }

    [NotMapped]

    private Permission? _permission { get; set; }

    
    public User()
    {
       // Claims = new List<Claim>();
        RefreshToken = new RefreshToken();
    }

    public User(uint userId, uint permissionVersion, Permission? permission)
    {
        Id = userId;
        PermissionVersion = permissionVersion;
        _permission = permission;
        //Claims = new List<Claim>();
        RefreshToken = new RefreshToken();
    }

    public void SetPermission(Permission permission)
    {
        this._permission = permission;
    }


    public bool IsPermitted(string? routeName)
    {
        if (_permission != null && _permission.RouteNames != null && _permission.RouteNames.Contains(routeName))
        {
            return true;
        }

        return false;
    }
}
