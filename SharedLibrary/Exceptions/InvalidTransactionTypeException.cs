namespace SharedLibrary.Exceptions;

public class InvalidTransactionTypeException : AppException
{
    public InvalidTransactionTypeException(string message, int exceptionCode) : base(message, exceptionCode)
    {
    }
}