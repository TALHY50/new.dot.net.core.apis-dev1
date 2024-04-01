namespace SharedLibrary.Exceptions;

public class NullResourceException : AppException
{
    
    public NullResourceException(string message, int exceptionCode) : base(message, exceptionCode)
    {
        this.ExceptionCode = exceptionCode;
    }
    
}