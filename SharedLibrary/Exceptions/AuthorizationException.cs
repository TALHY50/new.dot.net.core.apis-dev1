namespace SharedLibrary.Exceptions;

public class AuthorizationException : AppException
{
    public AuthorizationException(string message, int exceptionCode) : base(message, exceptionCode)
    {
        this.ExceptionCode = exceptionCode;
    }
    
}