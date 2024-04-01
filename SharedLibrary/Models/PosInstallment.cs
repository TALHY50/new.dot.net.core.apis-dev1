using Newtonsoft.Json;

namespace SharedLibrary.Models;

public partial class PosInstallment
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("pos_id")]
    public int PosId { get; set; }

    [JsonProperty("installments_number")]
    public int InstallmentsNumber { get; set; }

    [JsonProperty("cot_percentage")]
    public double CotPercentage { get; set; }

    /// <summary>
    /// 0=>inactive;1=>active;
    /// </summary>
    [JsonProperty("status")]
    public sbyte Status { get; set; }

    [JsonProperty("cot_fixed")]
    public double CotFixed { get; set; }

    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTime? UpdatedAt { get; set; }
}