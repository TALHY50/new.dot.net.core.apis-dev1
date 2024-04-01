namespace SharedLibrary.Exceptions;

public class PaymentAuthenticationException : FailedPaymentException
{
    
    public PaymentAuthenticationException(string message, int exceptionCode) : base(message, exceptionCode)
    {
        ExceptionCode = exceptionCode;
    }
}