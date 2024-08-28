using SharedKernel.Main.Contracts.Common;

namespace ACL.App.Contracts.Requests
{
    public class RefreshTokenRequest : Request
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
