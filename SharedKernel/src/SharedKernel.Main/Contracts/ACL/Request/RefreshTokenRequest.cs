namespace SharedKernel.Main.Contracts.ACL.Request
{
    public class RefreshTokenRequest : SharedKernel.Main.Contracts.Common.Request
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
