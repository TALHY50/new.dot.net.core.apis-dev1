namespace App.Application.Features.Auth.Register.Request
{
    public class RegisterRequest : Features.Request
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public IList<Domain.Auth.Claim> Claims { get; set; }
    }
}
