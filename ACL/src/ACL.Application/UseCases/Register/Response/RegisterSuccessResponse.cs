namespace ACL.Application.UseCases.Register.Response
{
    public class RegisterSuccessResponse : RegisterResponse
    {
        public ulong UserId { get; internal set; }
    }
}
