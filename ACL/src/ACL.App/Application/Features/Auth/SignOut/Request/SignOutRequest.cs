namespace ACL.App.Application.Features.Auth.SignOut.Request
{
    public class SignOutRequest : Features.Request
    {
        public uint UserId { get; set; }
    }
}
