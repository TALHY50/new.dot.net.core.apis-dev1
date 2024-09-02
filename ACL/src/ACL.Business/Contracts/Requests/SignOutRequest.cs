using SharedKernel.Main.Contracts;

namespace ACL.Business.Contracts.Requests
{
    public class SignOutRequest : Request
    {
        public uint UserId { get; set; }
    }
}
