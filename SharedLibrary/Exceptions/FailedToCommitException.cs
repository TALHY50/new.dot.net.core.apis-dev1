namespace SharedLibrary.Exceptions;

public class FailedToCommitException : AppException
{

    public FailedToCommitException(string msg, int code) : base(msg, code)
    {
        ExceptionCode = code;
    }
    
}