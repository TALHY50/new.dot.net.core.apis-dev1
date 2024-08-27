using SharedKernel.Main.Contracts.Common;

namespace ACL.App.Contracts.Requests
{
    public class SignOutRequest : Request
    {
        public uint UserId { get; set; }
    }
}
