using Newtonsoft.Json;

namespace SharedLibrary.Models;

public partial class SaleCurrencyConversion
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("order_id")]
    public string OrderId { get; set; } = null!;

    [JsonProperty("merchant_id")]
    public int MerchantId { get; set; }

    [JsonProperty("from_pos_id")]
    public int FromPosId { get; set; }

    [JsonProperty("to_pos_id")]
    public int ToPosId { get; set; }

    [JsonProperty("conversion_rate")]
    public double ConversionRate { get; set; }

    [JsonProperty("converted_amount")]
    public double ConvertedAmount { get; set; }

    [JsonProperty("original_amount")]
    public double OriginalAmount { get; set; }

    [JsonProperty("converted_total_refunded_amount")]
    public double ConvertedTotalRefundedAmount { get; set; }

    [JsonProperty("from_currency")]
    public string FromCurrency { get; set; } = null!;

    [JsonProperty("to_currency")]
    public string ToCurrency { get; set; } = null!;

    /// <summary>
    /// 1=normal conversion,2=dcc conversion
    /// </summary>
    [JsonProperty("conversion_type")]
    public sbyte? ConversionType { get; set; }

    [JsonProperty("migration_status")]
    public sbyte MigrationStatus { get; set; }

    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTime? UpdatedAt { get; set; }
}
