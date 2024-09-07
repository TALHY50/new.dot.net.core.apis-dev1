namespace ACL.Business.Contracts.Requests
{
    public class RefreshAccessTokenRequest
    {
        public string RefreshToken { get; set; }
        public string ClientId { get; set; }
    }
}