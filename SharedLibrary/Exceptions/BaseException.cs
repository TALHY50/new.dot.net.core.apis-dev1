namespace SharedLibrary.Exceptions;

public class BaseException : System.Exception
{

    private const string GeneralErrorCode = "0";
    private const string GeneralErrorDescription = "An error occurred.";
    private const string GeneralErrorGroup = "Unknown";

    public string ErrorCode { get; }

    public string ErrorDescription { get; }

    public string ErrorGroup { get; }

    public BaseException(string errorCode, string errorDescription, string errorGroup)
        : base(errorDescription)
    {
        this.ErrorCode = errorCode;
        this.ErrorDescription = errorDescription;
        this.ErrorGroup = errorGroup;
    }

    public BaseException(System.Exception exception)
        : base(exception.Message, exception)
    {
        this.ErrorCode = "0";
        this.ErrorDescription = "An error occurred.";
        this.ErrorGroup = "Unknown";
    }


}