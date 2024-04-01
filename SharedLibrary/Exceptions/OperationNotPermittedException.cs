namespace SharedLibrary.Exceptions;

public class OperationNotPermittedException : AppException
{

    public OperationNotPermittedException(string message, int code) : base(message, code)
    {
        ExceptionCode = code;
    }
    
}