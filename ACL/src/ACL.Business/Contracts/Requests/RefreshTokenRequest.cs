using SharedKernel.Main.Contracts;

namespace ACL.Business.Contracts.Requests
{
    public class RefreshTokenRequest : Request
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
