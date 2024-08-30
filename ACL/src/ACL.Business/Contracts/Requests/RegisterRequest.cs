using SharedKernel.Main.Contracts.Common;

namespace ACL.Business.Contracts.Requests
{
    public class RegisterRequest : Request
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public IList<Domain.Entities.Claim> Claims { get; set; }
    }
}
