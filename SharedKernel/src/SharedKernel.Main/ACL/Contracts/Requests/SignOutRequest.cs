using SharedKernel.Main.Contracts.Common;

namespace SharedKernel.Main.ACL.Contracts.Requests
{
    public class SignOutRequest : Request
    {
        public uint UserId { get; set; }
    }
}
