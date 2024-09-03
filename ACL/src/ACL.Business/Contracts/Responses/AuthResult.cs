using Newtonsoft.Json;

namespace ACL.Business.Contracts.Responses;

public class AuthResult
{
    [JsonProperty("token")]
    public string Token { get; set; }
}