namespace SharedKernel.Main.Contracts.ACL.Response
{
    public class SignOutErrorResponse : SignOutResponse
    {
        public string Message { get;  set; }
        public string Code { get;  set; }
    }
}
