namespace SharedLibrary.Exceptions;

public class FailedPaymentException : AppException
{
    public FailedPaymentException(string message, int code) : base(message, code)
    {
        ExceptionCode = code;
    }
}