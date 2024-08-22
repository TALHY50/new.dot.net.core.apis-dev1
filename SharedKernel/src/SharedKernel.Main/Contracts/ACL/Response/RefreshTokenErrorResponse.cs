namespace SharedKernel.Main.Contracts.ACL.Response
{
    public class RefreshTokenErrorResponse : RefreshTokenResponse
    {
        public string Message { get;  set; }
        public string Code { get;  set; }
    }
}
