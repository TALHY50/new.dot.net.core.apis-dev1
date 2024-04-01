using Newtonsoft.Json;

namespace SharedLibrary.Models;

public class PosCampaign
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("pos_id")]
    public int? PosId { get; set; }

    [JsonProperty("plus_installment")]
    public int? PlusInstallment { get; set; }

    [JsonProperty("min_installment")]
    public int? MinInstallment { get; set; }

    [JsonProperty("max_installment")]
    public int? MaxInstallment { get; set; }

    [JsonProperty("min_transaction_amount")]
    public double? MinTransactionAmount { get; set; }

    [JsonProperty("max_transaction_amount")]
    public double? MaxTransactionAmount { get; set; }

    [JsonProperty("from_date")]
    public DateTime? FromDate { get; set; }

    [JsonProperty("to_date")]
    public DateTime? ToDate { get; set; }

    /// <summary>
    /// 0=not for all, 1= for all
    /// </summary>
    [JsonProperty("is_all_merchant")]
    public sbyte? IsAllMerchant { get; set; }

    [JsonProperty("merchant_ids")]
    public string? MerchantIds { get; set; }

    /// <summary>
    /// 0= inactive, 1= active
    /// </summary>
    [JsonProperty("status")]
    public sbyte? Status { get; set; }

    [JsonProperty("days")]
    public string? Days { get; set; }

    /// <summary>
    /// 0=All; 1=Only For Commercial; 2=Only For Non-Commercial, 3 = On Us commercial, 4 = Not on Us commercial
    /// </summary>
    [JsonProperty("category")]
    public string Category { get; set; } = null!;

    [JsonProperty("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTime UpdatedAt { get; set; }
}
