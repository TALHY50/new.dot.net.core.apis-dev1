namespace ACL.Application.UseCases.Auth.SignOut.Request
{
    public class SignOutRequest : UseCases.Request
    {
        public uint UserId { get; set; }
    }
}
