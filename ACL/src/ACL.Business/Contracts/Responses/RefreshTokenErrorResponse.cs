namespace ACL.Business.Contracts.Responses
{
    public class RefreshTokenErrorResponse : RefreshTokenResponse
    {
        public string? Message { get;  set; }
        public string Code { get;  set; }
    }
}
