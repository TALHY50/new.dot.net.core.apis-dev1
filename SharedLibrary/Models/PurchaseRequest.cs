namespace SharedLibrary.Models;
using Newtonsoft.Json;

public partial class PurchaseRequest
{
    [JsonProperty("id")]
    public uint Id { get; set; }

    [JsonProperty("attempts")]
    public int Attempts { get; set; }

    /// <summary>
    /// Merchant Id of a Merchant
    /// </summary>
    [JsonProperty("merchant_id")]
    public int? MerchantId { get; set; }

    [JsonProperty("merchant_key")]
    public string MerchantKey { get; set; } = null!;

    [JsonProperty("ref")]
    public string Ref { get; set; } = null!;

    [JsonProperty("is_expired")]
    public bool IsExpired { get; set; }

    /// <summary>
    /// For Duplicate Purchase Request
    /// 0 = No Duplicate
    /// 1 = Found Duplicate
    /// 2 = Cancelled In Bank
    /// 3 = Temp Refund Request Created
    /// </summary>
    [JsonProperty("is_duplicate_invoice")]
    public sbyte? IsDuplicateInvoice { get; set; }

    [JsonProperty("data")]
    public string Data { get; set; } = null!;

    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [JsonProperty("currency_code")]
    public string? CurrencyCode { get; set; }

    [JsonProperty("currency_id")]
    public int? CurrencyId { get; set; }

    [JsonProperty("mobile_payment_status")]
    public sbyte? MobilePaymentStatus { get; set; }

    [JsonProperty("order_id")]
    public string? OrderId { get; set; }

    [JsonProperty("invoice_id")]
    public string? InvoiceId { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("surname")]
    public string? Surname { get; set; }

    [JsonProperty("ip")]
    public string? Ip { get; set; }

    [JsonProperty("lang")]
    public string? Lang { get; set; }

    [JsonProperty("migration_status")]
    public sbyte? MigrationStatus { get; set; }
}
