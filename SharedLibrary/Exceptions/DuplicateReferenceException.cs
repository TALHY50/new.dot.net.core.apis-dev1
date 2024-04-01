namespace SharedLibrary.Exceptions;

public class DuplicateReferenceException : AppException
{
    public DuplicateReferenceException(string message, int exceptionCode) : base(message, exceptionCode)
    {
    }
}