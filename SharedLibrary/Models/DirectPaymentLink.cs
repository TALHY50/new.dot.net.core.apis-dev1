using Newtonsoft.Json;

namespace SharedLibrary.Models;
public partial class DirectPaymentLink
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("amount")]
    public double? Amount { get; set; }

    [JsonProperty("currency")]
    public int Currency { get; set; }

    [JsonProperty("payment_method")]
    /// <summary>
    /// id from deposit_method table
    /// </summary>
    public int? PaymentMethod { get; set; }

    [JsonProperty("type")]
    /// <summary>
    /// 1 = first time, 2 = multi-time
    /// </summary>
    public int? Type { get; set; }

    [JsonProperty("expire_date")]
    /// <summary>
    /// expire date for muti-time
    /// </summary>
    public DateTime? ExpireDate { get; set; }

    [JsonProperty("expire_time")]
    /// <summary>
    /// time for single time
    /// </summary>
    public int? ExpireTime { get; set; }

    [JsonProperty("max_number_of_uses")]
    public int? MaxNumberOfUses { get; set; }

    [JsonProperty("number_of_uses")]
    public int? NumberOfUses { get; set; }

    [JsonProperty("gsm")]
    public string? Gsm { get; set; }

    [JsonProperty("email")]
    public string? Email { get; set; }

    [JsonProperty("photo")]
    public string? Photo { get; set; }

    [JsonProperty("name_of_product")]
    public string? NameOfProduct { get; set; }

    [JsonProperty("merchant_id")]
    public int MerchantId { get; set; }

    [JsonProperty("created_by")]
    /// <summary>
    /// user id of who created dpl link
    /// </summary>
    public int? CreatedBy { get; set; }

    [JsonProperty("created_by_name")]
    /// <summary>
    /// created by name
    /// </summary>
    public string? CreatedByName { get; set; }

    [JsonProperty("modified_by")]
    /// <summary>
    /// user id of who modified dpl
    /// </summary>
    public int? ModifiedBy { get; set; }

    [JsonProperty("modified_by_name")]
    /// <summary>
    /// modified by name
    /// </summary>
    public string? ModifiedByName { get; set; }

    [JsonProperty("token")]
    public string Token { get; set; } = null!;

    [JsonProperty("status")]
    public string Status { get; set; } = null!;

    [JsonProperty("is_email_send")]
    /// <summary>
    /// cronjob email send for dpl 1 = sent 0 = not sent
    /// </summary>
    public sbyte IsEmailSend { get; set; }

    [JsonProperty("description")]
    public string? Description { get; set; }

    [JsonProperty("distance_sale_status")]
    public sbyte? DistanceSaleStatus { get; set; }

    [JsonProperty("is_amount_set_by_user")]
    public sbyte? IsAmountSetByUser { get; set; }

    [JsonProperty("min_installment_limit")]
    public sbyte? MinInstallmentLimit { get; set; }

    [JsonProperty("max_installment_limit")]
    public int? MaxInstallmentLimit { get; set; }

    [JsonProperty("is_recurring")]
    /// <summary>
    /// 0 = Not Recurring, 1 = Recurring
    /// </summary>
    public sbyte? IsRecurring { get; set; }

    [JsonProperty("is_enabled")]
    /// <summary>
    /// 0 = not enabled, 1 = enabled
    /// </summary>
    public sbyte? IsEnabled { get; set; }

    [JsonProperty("saved_link_title")]
    /// <summary>
    /// If this column is not empty, then it will be considered as saved link
    /// </summary>
    public string? SavedLinkTitle { get; set; }

    [JsonProperty("is_preauth")]
    /// <summary>
    /// 0 = not allowed, 1 = allow
    /// </summary>
    public sbyte? IsPreauth { get; set; }

    [JsonProperty("is_shown_in_list")]
    /// <summary>
    /// 0 = not shown, 1 = shown. when this value is true, It should not be listed in merchant panel list and make it expired
    /// </summary>
    public sbyte IsShownInList { get; set; }

    [JsonProperty("dpl_pos_option")]
    /// <summary>
    /// 0 = 2d, 1 = 3D, 2 = Allow 2D And 3D
    /// </summary>
    public sbyte? DplPosOption { get; set; }

    [JsonProperty("is_comission_from_user")]
    /// <summary>
    /// 1 => take commission from user
    /// 2 => do not take commission from user; user fee forcefully 0
    /// </summary>
    public sbyte IsComissionFromUser { get; set; }

    [JsonProperty("commission_for_installment")]
    public string? CommissionForInstallment { get; set; }

    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [JsonProperty("action_by_id")]
    /// <summary>
    /// Authenticated user id
    /// </summary>
    public int ActionById { get; set; }

    public const int FIRST_TIME_PAYMENT_LINK = 1;
    public const int MULTI_TIME_PAYMENT_LINK = 2;
    public const int ONE_PAGE_PAYMENT_LINK = 3;
    public const bool EMAIL_SEND = true;
    public const bool NOT_EMAIL_SEND = false;
    public const bool IS_ACTIVE = true;
    public const bool IS_INACTIVE = false;
    public const string ACTIVE = "ACTIVE";
    public const string FAILED = "FAILED";
    public const string COMPLETED = "COMPLETED";
    public const string USED = "USED";
    public const string EXPIRED = "EXPIRED";
    public const int DPL_HTTPS_ERROR_CODE = 301;
    public const int TAKE_COMISSION_FROM_USER = 1;
    public const int DO_NOT_TAKE_COMISSION_FROM_USER = 2;
    public const int EXISTING_PROCESS = 0;
    public const bool IS_SHOWM_IN_LIST_SHOW = true;
    public const bool IS_SHOWM_IN_LIST_NOT_SHOW = false;
    public static readonly string[] UPLOAD_FILE_TYPES = new string[] { "xlsx", "xls" }; //file extension
    public const int UPLOAD_FILE_SIZE = 5;
    public const bool SENT_DPL_LINK_TO_MULTIPLE_USERS = true;
    public const int IS_ENABLE_PREAUTH = 1;
    public const int IS_NOT_ENABLE_PREAUTH = 0;
    public const int IS_ALLOW_RECURRING = 1;
    public const int IS_NOT_ALLOW_RECURRING = 0;
    public const int IS_2D = 1;
    public const int IS_3D = 0;
}
