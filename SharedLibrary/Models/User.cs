using Newtonsoft.Json;

namespace SharedLibrary.Models;

public partial class User
{
    [JsonProperty("id")]
    public uint Id { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("first_name")]
    public string? FirstName { get; set; }

    [JsonProperty("last_name")]
    public string? LastName { get; set; }

    [JsonProperty("email")]
    public string? Email { get; set; }

    [JsonProperty("avatar")]
    public string? Avatar { get; set; }

    [JsonProperty("password")]
    public string? Password { get; set; }

    [JsonProperty("ip")]
    public string? Ip { get; set; }

    [JsonProperty("dob")]
    public DateOnly? Dob { get; set; }

    [JsonProperty("token_phone")]
    public string? TokenPhone { get; set; }

    [JsonProperty("token_phone_datetime")]
    public DateTime? TokenPhoneDatetime { get; set; }

    [JsonProperty("token_email")]
    public string? TokenEmail { get; set; }

    [JsonProperty("token_email_datetime")]
    public DateTime? TokenEmailDatetime { get; set; }

    [JsonProperty("gender")]
    public sbyte? Gender { get; set; }
    /// <summary>
    /// 1=Male, 2=Female
    /// </summary>

    [JsonProperty("address")]
    public string? Address { get; set; }

    [JsonProperty("city")]
    public string? City { get; set; }

    [JsonProperty("country")]
    public int Country { get; set; }

    [JsonProperty("phone")]
    public string? Phone { get; set; }

    [JsonProperty("verified")]
    public bool Verified { get; set; }

    /// <summary>
    /// 0=Pending, 1=Approved, 2=Not Approved, 3=Lock User
    /// </summary>

    [JsonProperty("is_admin_verified")]
    public sbyte IsAdminVerified { get; set; }

    [JsonProperty("merchant")]
    public bool Merchant { get; set; }

    [JsonProperty("social")]
    public bool Social { get; set; }

    [JsonProperty("balance")]
    public double Balance { get; set; }

    [JsonProperty("tc_number")]
    public string? TcNumber { get; set; }

    [JsonProperty("contracted_file")]
    public string? ContractedFile { get; set; }
    /// <summary>
    /// 0=&gt;customer; 1=&gt;admin; 2=&gt;merchant; 3=&gt;submerchant
    /// </summary>

    [JsonProperty("user_type")]
    public int UserType { get; set; }

    [JsonProperty("json_data")]
    public string? JsonData { get; set; }

    [JsonProperty("account_status")]
    public bool? AccountStatus { get; set; }

    [JsonProperty("remember_token")]
    public string? RememberToken { get; set; }
    /// <summary>
    /// Stores the id of the user session
    /// </summary>

    [JsonProperty("session_id")]
    public string? SessionId { get; set; }

    [JsonProperty("settings")]
    public string? Settings { get; set; }
    /// <summary>
    /// 0 = Right password has been attempted,1=Wrong password has been attempted
    /// </summary>

    [JsonProperty("failed_login_attempt")]
    public sbyte? FailedLoginAttempt { get; set; }

    [JsonProperty("last_failed_login_datetime")]
    public DateTime? LastFailedLoginDatetime { get; set; }

    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonProperty("activated_at")]
    public DateTime? ActivatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [JsonProperty("updated_password_at")]
    public DateTime? UpdatedPasswordAt { get; set; }

    [JsonProperty("ticketit_admin")]
    public bool TicketitAdmin { get; set; }

    [JsonProperty("ticketit_agent")]
    public bool TicketitAgent { get; set; }

    [JsonProperty("currency_id")]
    public int? CurrencyId { get; set; }

    [JsonProperty("is_ticket_admin")]
    public int? IsTicketAdmin { get; set; }

    [JsonProperty("verification_token")]
    public string? VerificationToken { get; set; }

    [JsonProperty("unique_invitation_link_key")]
    public string? UniqueInvitationLinkKey { get; set; }

    [JsonProperty("first_time_login")]
    public bool? FirstTimeLogin { get; set; }

    [JsonProperty("language")]
    public string? Language { get; set; }

    [JsonProperty("username")]
    public string? Username { get; set; }

    [JsonProperty("img_path")]
    public string? ImgPath { get; set; }

    [JsonProperty("reset_password_token")]
    public string? ResetPasswordToken { get; set; }

    /// <summary>
    /// 0=&gt;Inactive or disable; 1=&gt;enable or active; 2=&gt; disabled or suspected;3= awaiting disable or banned;4=awaiting GSM
    /// </summary>

    [JsonProperty("status")]
    public sbyte Status { get; set; }

    [JsonProperty("company_id")]
    public int CompanyId { get; set; }

    [JsonProperty("merchant_parent_user_id")]
    public int? MerchantParentUserId { get; set; }

    [JsonProperty("fb_id")]
    public string? FbId { get; set; }

    [JsonProperty("permission_version")]
    public int PermissionVersion { get; set; }
    /// <summary>
    /// 1=&gt;UNKNOWN, 2=&gt;UNVERIFIED, 3=&gt;VERIFIED, 4=&gt;CONTRACT
    /// </summary>

    [JsonProperty("user_category")]
    public sbyte UserCategory { get; set; }

    [JsonProperty("sector_id")]
    public int? SectorId { get; set; }

    [JsonProperty("question_one")]
    public string? QuestionOne { get; set; }

    [JsonProperty("wrong_secret_answer_attempt")]
    public sbyte? WrongSecretAnswerAttempt { get; set; }

    [JsonProperty("answer_one")]
    public string? AnswerOne { get; set; }

    /// <summary>
    /// 1=&gt; otp required, 0=&gt; otp not required
    /// </summary>

    [JsonProperty("is_otp_required")]
    public sbyte? IsOtpRequired { get; set; }
    /// <summary>
    /// 0 =&gt; all channel like sms, email
    /// 1 =&gt; only sms
    /// 2=&gt; only email
    /// </summary>

    [JsonProperty("otp_channel")]
    public sbyte OtpChannel { get; set; }
    /// <summary>
    /// 0 =&gt; not Verified
    /// 1 =&gt; Verified
    /// </summary>

    [JsonProperty("is_email_verified")]
    public sbyte IsEmailVerifyed { get; set; }

    [JsonProperty("customer_number")]
    public string? CustomerNumber { get; set; }

    /// <summary>
    /// id from security_images table
    /// </summary>

    [JsonProperty("security_image_id")]
    public int? SecurityImageId { get; set; }

    [JsonProperty("last_activity_datetime")]
    public DateTime? LastActivityDatetime { get; set; }
    /// <summary>
    /// user logged in time
    /// </summary>

    [JsonProperty("login_at")]
    public DateTime? LoginAt { get; set; }

    /// <summary>
    /// 0 = Not Restricted, 1= this user will be restricted to see the merchants only which are under this account as account manager
    /// 
    /// 
    /// </summary>

    [JsonProperty("is_merchant_restricted_by_account_manager")]
    public bool? IsMerchantRestrictedByAccountManager { get; set; }

    [JsonProperty("created_by_id")]
    public int? CreatedById { get; set; }

    [JsonProperty("created_by_name")]
    public string? CreatedByName { get; set; }

    [JsonProperty("is_online")]
    public bool? IsOnline { get; set; }

    [JsonProperty("last_seen")]
    public DateTime? LastSeen { get; set; }
    /// <summary>
    /// 0=&gt;Default, 1=&gt;User Self Deactivation
    /// </summary>

    [JsonProperty("is_self_deactivated")]
    public sbyte IsSelfDeactivated { get; set; }

    /// <summary>
    /// User deactivation date 
    /// </summary>

    [JsonProperty("self_deactivation_date")]
    public DateTime? SelfDeactivationDate { get; set; }
    /// <summary>
    /// 1 =  global, who can see all records of merchant,  0 = local, who  can  see only his/her own created  records
    /// </summary>

    [JsonProperty("user_privilege_type")]
    public sbyte? UserPrivilegeType { get; set; }
    /// <summary>
    /// 0=&gt;Default, 1=&gt;Request send to admin
    /// </summary>
    [JsonProperty("is_send_activation_request")]
    public sbyte IsSendActivationRequest { get; set; }

    [JsonProperty("user_roles")]
    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}

