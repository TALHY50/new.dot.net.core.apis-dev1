namespace SharedLibrary.Exceptions;

public class InvalidCardHolderInformationException : AppException
{
    public InvalidCardHolderInformationException(string message, int exceptionCode) : base(message, exceptionCode)
    {
    }
}