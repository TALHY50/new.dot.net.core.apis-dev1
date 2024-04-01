namespace SharedLibrary.Exceptions;

public class SavedCardBankNotFoundException : AppException
{
    public SavedCardBankNotFoundException(string message, int exceptionCode) : base(message, exceptionCode)
    {
    }
}