namespace ACL.Application.UseCases.CreateUser.Response
{
    public class CreateUserSuccessResponse : CreateUserResponse
    {
        public ulong UserId { get; internal set; }
    }
}
