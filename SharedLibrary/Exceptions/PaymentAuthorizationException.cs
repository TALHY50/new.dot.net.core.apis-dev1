namespace SharedLibrary.Exceptions;

public class PaymentAuthorizationException : FailedPaymentException
{
    public PaymentAuthorizationException(string messgae, int code) : base(messgae, code)
    {
        ExceptionCode = code;
    }
}