using Newtonsoft.Json;

namespace SharedLibrary.Models;
public partial class TmpPaymentRecord
{
    public int Id { get; set; }

    [JsonProperty("order_id")]
    public string OrderId { get; set; } = null!;

    [JsonProperty("bank_id")]
    public int BankId { get; set; }

    [JsonProperty("bank_url")]
    public string? BankUrl { get; set; }

    [JsonProperty("token_url")]
    public string? TokenUrl { get; set; }

    [JsonProperty("client_id")]
    public string? ClientId { get; set; }

    [JsonProperty("username")]
    public string? Username { get; set; }

    [JsonProperty("password")]
    public string? Password { get; set; }

    [JsonProperty("bank_code")]
    public string BankCode { get; set; } = null!;

    [JsonProperty("payment_provider")]
    public string PaymentProvider { get; set; } = null!;

    [JsonProperty("dpl_id")]
    public int? DplId { get; set; }

    [JsonProperty("dpl_token")]
    public string? DplToken { get; set; }

    [JsonProperty("invoice_id")]
    public string InvoiceId { get; set; } = null!;

    [JsonProperty("session_data")]
    public string SessionData { get; set; } = null!;

    [JsonProperty("comission")]
    public string? Comission { get; set; }

    [JsonProperty("commission")]
    public string? Commission { get; set; }

    [JsonProperty("attempts")]
    public sbyte Attempts { get; set; }

    /// <summary>
    /// 1=>Sale, 2=>Deposit
    /// </summary>
    [JsonProperty("type")]
    public sbyte Type { get; set; }

    /// <summary>
    /// 1=auth , 2=PreAuth
    /// </summary>
    [JsonProperty("sale_type")]
    public sbyte SaleType { get; set; }

    [JsonProperty("is_allow_order_status")]
    public sbyte? IsAllowOrderStatus { get; set; }

    [JsonProperty("remote_order_id")]
    public string? RemoteOrderId { get; set; }

    [JsonProperty("ip")]
    public string? Ip { get; set; }

    [JsonProperty("invoice_details")]
    public string? InvoiceDetails { get; set; }

    [JsonProperty("merchant_key")]
    public string? MerchantKey { get; set; }

    /// <summary>
    /// merchant id from merchants table
    /// </summary>
    [JsonProperty("merchant_id")]
    public int? MerchantId { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("surname")]
    public string? Surname { get; set; }

    [JsonProperty("currency_id")]
    public int? CurrencyId { get; set; }

    [JsonProperty("currency_code")]
    public string? CurrencyCode { get; set; }

    [JsonProperty("is_pre_auth_pending")]
    public sbyte? IsPreAuthPending { get; set; }

    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// 1=active, 0=inactive, 2=waiting for delete, 5= Special Order Status, 6= Waiting for PreAuth confirm/reject event
    /// </summary>
    [JsonProperty("status")]
    public sbyte Status { get; set; }
}
