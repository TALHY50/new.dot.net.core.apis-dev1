using SharedKernel.Main.Contracts.Common;

namespace ACL.Bussiness.Contracts.Requests
{
    public class SignOutRequest : Request
    {
        public uint UserId { get; set; }
    }
}
