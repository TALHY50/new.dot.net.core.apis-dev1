namespace SharedLibrary.Exceptions;

public class SavedCardOperationFailedException : AppException
{
    public SavedCardOperationFailedException(string message, int exceptionCode) : base(message, exceptionCode)
    {
    }
}