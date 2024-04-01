namespace SharedLibrary.Exceptions;

public class RestrictedIpException : AppException
{
    public RestrictedIpException(string message, int exceptionCode) : base(message, exceptionCode)
    {
        this.ExceptionCode = exceptionCode;
    }
}