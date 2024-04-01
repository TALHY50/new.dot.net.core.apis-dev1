namespace SharedLibrary.Exceptions;

public class AmountExceededException : AppException
{
    public AmountExceededException(string message, int exceptionCode) : base(message, exceptionCode)
    {
    }
}