namespace SharedKernel.Main.Contracts.ACL.Request
{
    public class RegisterRequest : SharedKernel.Main.Contracts.Common.Request
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public IList<SharedKernel.Main.Domain.ACL.Domain.Auth.Claim> Claims { get; set; }
    }
}
