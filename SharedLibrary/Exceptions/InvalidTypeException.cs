namespace SharedLibrary.Exceptions;

public class InvalidTypeException : AppException
{
    
    public InvalidTypeException(string message, int exceptionCode) : base(message, exceptionCode)
    {
        this.ExceptionCode = exceptionCode;
    }
    
}