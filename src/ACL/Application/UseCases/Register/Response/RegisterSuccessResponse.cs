namespace ACL.Application.UseCases.CreateUser.Response
{
    public class RegisterSuccessResponse : RegisterResponse
    {
        public ulong UserId { get; internal set; }
    }
}
