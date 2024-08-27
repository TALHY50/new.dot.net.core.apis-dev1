namespace ACL.App.Contracts.Responses
{
    public class RefreshTokenErrorResponse : RefreshTokenResponse
    {
        public string Message { get;  set; }
        public string Code { get;  set; }
    }
}
