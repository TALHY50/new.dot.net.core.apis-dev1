using IMT.Thunes.Response.Common;
using exception = System.Exception;

namespace IMT.Thunes.Exception
{
    public class ThunesException : exception
    {
        private const int GeneralErrorCode = 0;
        private const string GeneralErrorDescription = "An error occurred.";
        private const string GeneralErrorGroup = "Unknown";
        public int ErrorCode { get; }
        public string ErrorDescription { get; }
        public List<ErrorsResponse> Errors { get; }

        public ThunesException(int errorCode, string errorDescription)
            : base(errorDescription)
        {
            ErrorCode = errorCode;
            ErrorDescription = errorDescription;
        }

        public ThunesException(exception exception)
            : base(exception.Message, exception)
        {
            ErrorCode = GeneralErrorCode;
            ErrorDescription = GeneralErrorDescription;
        }
        public ThunesException(int errorCode, List<ErrorsResponse> errorDescription)
        {
            ErrorCode = errorCode;
            Errors = errorDescription;
        }
    }
}