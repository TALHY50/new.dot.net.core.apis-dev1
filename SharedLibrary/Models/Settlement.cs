using Newtonsoft.Json;

namespace SharedLibrary.Models;

public partial class Settlement
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("code")]
    public string? Code { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("name_tr")]
    public string NameTr { get; set; } = null!;

    [JsonProperty("type")]
    public string? Type { get; set; }

    [JsonProperty("value")]
    public string? Value { get; set; }

    /// <summary>
    ///  (1=active, 0=inactive)
    /// </summary>
    [JsonProperty("status")]
    public sbyte Status { get; set; }

    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTime? UpdatedAt { get; set; }
}
