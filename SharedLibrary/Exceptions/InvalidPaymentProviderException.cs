namespace SharedLibrary.Exceptions;

public class InvalidPaymentProviderException : AppException
{
    public InvalidPaymentProviderException(string message, int exceptionCode) : base(message, exceptionCode)
    {
    }
}