namespace SharedLibrary.Exceptions;

public class InvalidCurrencyException : AppException
{
    public InvalidCurrencyException(string message, int exceptionCode) : base(message, exceptionCode)
    {
    }
}