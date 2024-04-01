namespace SharedLibrary.Exceptions;

public class InvalidRequestParameterException : AppException
{
    public InvalidRequestParameterException(string message, int exceptionCode) : base(message, exceptionCode)
    {
    }
}