namespace SharedLibrary.Exceptions;

public class InsufficientBalanceException : AppException
{
    public InsufficientBalanceException(string message, int exceptionCode) : base(message, exceptionCode)
    {
        ExceptionCode = exceptionCode;
    }
}