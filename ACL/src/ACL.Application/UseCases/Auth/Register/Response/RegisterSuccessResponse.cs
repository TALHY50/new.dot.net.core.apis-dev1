namespace ACL.Application.UseCases.Auth.Register.Response
{
    public class RegisterSuccessResponse : RegisterResponse
    {
        public ulong UserId { get; internal set; }
    }
}
