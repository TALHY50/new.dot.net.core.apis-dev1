namespace ACL.Application.UseCases.Auth.Register.Response
{
    public class RegisterErrorResponse : RegisterResponse
    {
        public string Message { get; internal set; }
        public string Code { get; internal set; }
    }
}
