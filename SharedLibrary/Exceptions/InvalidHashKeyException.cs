namespace SharedLibrary.Exceptions;

public class InvalidHashKeyException : AppException
{
    public InvalidHashKeyException(string message, int exceptionCode) : base(message, exceptionCode)
    {
    }
}