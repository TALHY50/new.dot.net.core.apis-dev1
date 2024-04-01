namespace SharedLibrary.Exceptions;

public class PaymentCardException : AppException
{
    public PaymentCardException(string message, int exceptionCode) : base(message, exceptionCode)
    {
    }
}