namespace ACL.Application.Features.Auth.RefreshToken.Response
{
    public class RefreshTokenSuccessResponse : RefreshTokenResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpirationDate { get; set; }
    }
}
