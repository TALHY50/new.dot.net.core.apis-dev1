namespace ACL.Application.UseCases.CreateUser.Request
{
    public class RegisterRequest : UseCases.Request
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public IList<Core.Models.Claim> Claims { get; set; }
    }
}
