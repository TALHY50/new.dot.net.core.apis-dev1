namespace SharedLibrary.Exceptions;

public class MismatchedTarimDataException : AppException
{
    public MismatchedTarimDataException(string message, int exceptionCode) : base(message, exceptionCode)
    {
    }
}