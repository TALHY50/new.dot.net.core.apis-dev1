namespace SharedKernel.Main.ACL.Contracts.Responses
{
    public class RefreshTokenSuccessResponse : RefreshTokenResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpirationDate { get; set; }
    }
}
