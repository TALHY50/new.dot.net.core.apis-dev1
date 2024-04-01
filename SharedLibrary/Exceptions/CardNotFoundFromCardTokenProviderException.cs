namespace SharedLibrary.Exceptions;

public class CardNotFoundFromCardTokenProviderException : AppException
{
    public CardNotFoundFromCardTokenProviderException(string message, int exceptionCode) : base(message, exceptionCode)
    {
    }
}