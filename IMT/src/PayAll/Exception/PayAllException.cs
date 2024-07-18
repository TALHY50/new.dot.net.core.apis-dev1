using exception = System.Exception;

namespace IMT.PayAll.Exception
{
    public class PayAllException : exception
    {
        private const string GeneralErrorCode = "0";
        private const string GeneralErrorDescription = "An error occurred.";
        private const string GeneralErrorGroup = "Unknown";
        public string ErrorCode { get; }
        public string ErrorDescription { get; }
        public object ErrorGroup { get; }

        public PayAllException(string errorCode, string errorDescription, object errorGroup): base(errorDescription)
        {
            ErrorCode = errorCode;
            ErrorDescription = errorDescription;
            ErrorGroup = errorGroup;
        }

        public PayAllException(exception exception): base(exception.Message, exception)
        {
            ErrorCode = GeneralErrorCode;
            ErrorDescription = GeneralErrorDescription;
            ErrorGroup = GeneralErrorGroup;
        }
    }
}