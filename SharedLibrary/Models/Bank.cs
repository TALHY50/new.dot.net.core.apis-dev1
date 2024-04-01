using Newtonsoft.Json;
using SharedLibrary.Utilities;
using System.ComponentModel.DataAnnotations.Schema;
using SharedLibrary.Services;

namespace SharedLibrary.Models;
public partial class Bank
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("code")]
    public string? Code { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; } = null!;

    [JsonProperty("issuer_name")]
    public string? IssuerName { get; set; }

    [JsonProperty("client_id")]
    public string? ClientId { get; set; }

    [JsonProperty("user_name")]
    public string? UserName { get; set; }

    [JsonProperty("password")]
    public string? Password { get; set; }

    [JsonProperty("store_key")]
    public string? StoreKey { get; set; }

    [JsonProperty("store_type")]
    public string? StoreType { get; set; }

    [JsonProperty("gate3d_url")]
    public string? Gate3dUrl { get; set; }

    [JsonProperty("api_url")]
    public string? ApiUrl { get; set; }

    [JsonProperty("refund_url")]
    public string? RefundUrl { get; set; }

    [JsonProperty("link_generate_url")]
    public string? LinkGenerateUrl { get; set; }

    /// <summary>
    /// Url for insurance payment
    /// </summary>
    [JsonProperty("insurance_payment_url")]
    public string? InsurancePaymentUrl { get; set; }

    [JsonProperty("api_user_name")]
    public string? ApiUserName { get; set; }

    [JsonProperty("api_password")]
    public string? ApiPassword { get; set; }

    [JsonProperty("address")]
    public string Address { get; set; } = null!;

    [JsonProperty("country")]
    public string Country { get; set; } = null!;

    [JsonProperty("country_id")]
    public int CountryId { get; set; }

    [JsonProperty("logo")]
    public string? Logo { get; set; }

    /// <summary>
    /// 1=&gt; active, 0=&gt;inactive
    /// </summary>
    [JsonProperty("status")]
    public sbyte Status { get; set; }

    [JsonProperty("is_shown_in_admin")]
    public sbyte IsShownInAdmin { get; set; }

    [JsonProperty("is_shown_in_merchant")]
    public sbyte IsShownInMerchant { get; set; }

    [JsonProperty("is_shown_in_user")]
    public sbyte IsShownInUser { get; set; }

    [JsonProperty("bank_identity")]
    public string? BankIdentity { get; set; }

    [JsonProperty("payment_provider")]
    public string? PaymentProvider { get; set; }

    [JsonProperty("token_url")]
    public string? TokenUrl { get; set; }

    [JsonProperty("gate2d_url")]
    public string? Gate2dUrl { get; set; }

    [JsonProperty("is_allow_2d")]
    public sbyte? IsAllow2d { get; set; }

    [JsonProperty("is_allow_3d")]
    public sbyte? IsAllow3d { get; set; }

    /// <summary>
    /// 0=not allowed, 1 = allowed
    /// </summary>
    [JsonProperty("is_allow_2d_cvvless")]
    public sbyte? IsAllow2dCvvless { get; set; }

    /// <summary>
    /// 0=not allowed, 1 = allowed
    /// </summary>
    [JsonProperty("is_allow_3d_cvvless")]
    public sbyte? IsAllow3dCvvless { get; set; }

    [JsonProperty("is_allow_order_status")]
    public sbyte? IsAllowOrderStatus { get; set; }

    [JsonProperty("is_allow_recurring")]
    public sbyte? IsAllowRecurring { get; set; }

    [JsonProperty("is_allow_refund")]
    public sbyte? IsAllowRefund { get; set; }

    /// <summary>
    /// is_actual_bank = 1 means ccpayment real integration(2d,3d, order status,, refund etc) banks. otherwise, it is dummy entry to show list on withdrawal and manual deposit screen
    /// </summary>
    [JsonProperty("is_actual_bank")]
    public sbyte? IsActualBank { get; set; }

    [JsonProperty("iban_code")]
    public string IbanCode { get; set; } = null!;

    /// <summary>
    /// posnet id from posnet unitOfWork
    /// </summary>
    [JsonProperty("posnet_id")]
    public string? PosnetId { get; set; }

    /// <summary>
    /// Terminal ID 
    /// </summary>
    [JsonProperty("terminal_id")]
    public string? TerminalId { get; set; }

    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [NotMapped]
    public string? DecryptedClientId
    {
        get
        {
            // Decrypt the value and return it
            return Cryptographer.AppDecrypt(this.ClientId);
        }
    }

    [NotMapped]
    public string? DecryptedUserName
    {
        get
        {
            // Decrypt the value and return it
            return Cryptographer.AppDecrypt(this.UserName);
        }
    }

    [NotMapped]
    public string? DecryptedPassword
    {
        get
        {
            // Decrypt the value and return it
            return Cryptographer.AppDecrypt(this.Password);
        }
    }

    [NotMapped]
    public string? DecryptedApiUserName
    {
        get
        {
            // Decrypt the value and return it
            return Cryptographer.AppDecrypt(this.ApiUserName);
        }
    }
    
    public string? DecryptedApiPassword
    {
        get
        {
            // Decrypt the value and return it
            return Cryptographer.AppDecrypt(this.ApiPassword);
        }
    }


    [NotMapped]
    public string? DecryptedStoreKey
    {
        get
        {
            // Decrypt the value and return it
            return Cryptographer.AppDecrypt(this.StoreKey);
        }
    }

    public const int ALL = 2;
    public const int ACTIVE = 1;
    public const int INACTIVE = 0;
    public const int TR_COUNTRY_ID = 218;
    public const string STORE_TYPE_3D = "3d";
    public const string STORE_TYPE_3D_PAY_HOSTING = "3d_pay_hosting";
}
