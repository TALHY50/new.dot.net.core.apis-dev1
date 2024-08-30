namespace ACL.Business.Contracts.Responses
{
    public class RegisterErrorResponse : RegisterResponse
    {
        public string Message { get;  set; }
        public string Code { get;  set; }
    }
}
