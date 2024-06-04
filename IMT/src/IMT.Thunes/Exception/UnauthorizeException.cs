using exception = System.Exception;

namespace IMT.Thunes.Exception
{
    public class UnauthorizeException : exception
    {
        private const string GeneralErrorCode = "0";
        private const string GeneralErrorDescription = "An error occurred.";
        public string ErrorCode { get; }
        public string ErrorDescription { get; }

        public UnauthorizeException(string errorCode, string errorDescription)
            : base(errorDescription)
        {
            ErrorCode = errorCode;
            ErrorDescription = errorDescription;
        }

        public UnauthorizeException(object errorCode, exception exception)
            : base(exception.Message, exception)
        {
            ErrorCode = GeneralErrorCode;
            ErrorDescription = GeneralErrorDescription;
        }
    }
}