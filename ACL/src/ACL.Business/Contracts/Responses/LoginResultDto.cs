namespace ACL.Business.Contracts.Responses;

public class LoginResultDto
{
    public string token_type { get; set; }
    public string access_token { get; set; }
    public long expires_in { get; set; }
    public string refresh_token { get; set; }
}