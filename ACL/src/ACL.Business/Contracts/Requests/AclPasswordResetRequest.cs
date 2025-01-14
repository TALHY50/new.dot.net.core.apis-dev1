﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ACL.Business.Contracts.Requests;

public partial class AclPasswordResetRequest
{
    [DefaultValue("10")]
    [Required(ErrorMessage = "User ID is required")]
    [Range(1, uint.MaxValue, ErrorMessage = "User ID greater than 0.")]
    //[ExistsInDatabase<ApplicationDbContext,ICustomUnitOfWork>("User", "Id")]
    public uint UserId { get; set; }

    [DefaultValue("12345678")]
    [Required(ErrorMessage = "Current password is required")]
    public string CurrentPassword { get; set; }

    [DefaultValue("12345678")]
    [Required(ErrorMessage = "New password is required")]
    public string NewPassword { get; set; }

    [DefaultValue("12345678")]
    [Required(ErrorMessage = "Password confirmation is required")]
    [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
    public string PasswordConfirmation { get; set; }


}
