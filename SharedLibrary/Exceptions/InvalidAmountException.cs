namespace SharedLibrary.Exceptions;

public class InvalidAmountException : AppException
{
    public InvalidAmountException(string message, int exceptionCode) : base(message, exceptionCode)
    {
    }
}