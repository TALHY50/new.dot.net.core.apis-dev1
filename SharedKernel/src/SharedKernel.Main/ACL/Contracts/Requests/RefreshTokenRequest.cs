using SharedKernel.Main.Contracts.Common;

namespace SharedKernel.Main.ACL.Contracts.Requests
{
    public class RefreshTokenRequest : Request
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
