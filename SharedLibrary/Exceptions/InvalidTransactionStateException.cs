namespace SharedLibrary.Exceptions;

public class InvalidTransactionStateException : AppException
{
    public InvalidTransactionStateException(string message, int exceptionCode) : base(message, exceptionCode)
    {
    }
}