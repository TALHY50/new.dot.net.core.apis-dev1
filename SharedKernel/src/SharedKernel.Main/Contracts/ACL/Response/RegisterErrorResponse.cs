namespace SharedKernel.Main.Contracts.ACL.Response
{
    public class RegisterErrorResponse : RegisterResponse
    {
        public string Message { get;  set; }
        public string Code { get;  set; }
    }
}
