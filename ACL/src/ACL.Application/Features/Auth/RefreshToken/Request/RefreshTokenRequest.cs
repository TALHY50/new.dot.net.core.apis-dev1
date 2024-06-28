namespace ACL.Application.Features.Auth.RefreshToken.Request
{
    public class RefreshTokenRequest : Features.Request
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
