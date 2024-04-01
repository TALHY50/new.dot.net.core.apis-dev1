using Newtonsoft.Json;

namespace SharedLibrary.Models;
public partial class MerchantPosCommission
{
    [JsonProperty("id")]
    public ulong Id { get; set; }

    [JsonProperty("merchant_id")]
    public int MerchantId { get; set; }

    [JsonProperty("pos_id")]
    public int PosId { get; set; }

    [JsonProperty("installment_number")]
    public int InstallmentNumber { get; set; }

    [JsonProperty("com_percentage")]
    public decimal? ComPercentage { get; set; }

    [JsonProperty("com_fixed")]
    public decimal? ComFixed { get; set; }

    [JsonProperty("end_user_com_percentage")]
    public double EndUserComPercentage { get; set; }

    [JsonProperty("end_user_com_fixed")]
    public double? EndUserComFixed { get; set; }

    [JsonProperty("status")]
    public sbyte Status { get; set; }

    [JsonProperty("is_allow_foreign_card")]
    public sbyte IsAllowForeignCard { get; set; }

    [JsonProperty("created_by_id")]
    public int? CreatedById { get; set; }

    [JsonProperty("updated_by_id")]
    public int? UpdatedById { get; set; }

    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTime? UpdatedAt { get; set; }
}
