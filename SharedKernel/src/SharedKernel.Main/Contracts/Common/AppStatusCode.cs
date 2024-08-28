namespace SharedKernel.Main.Contracts.Common
{
    public static partial class AppStatusCode
    {
        public static readonly int SUCCESS = 100;
        public static readonly int OTP_SUCCESS = 101;
        public static readonly int IN_REVIEW_SUCCESS = 102;
        public static readonly int FAIL = 99;
        public static readonly int UNAUTHENTICATED = 401;
        public static readonly int PERMISSION_DENIED = 403;
        public static readonly int NOTFOUND = 404;
        public static readonly int CONFLICT = 409;
        public static readonly int CorridorNotFound = 1101;


    }
    //Success,Error,Warning,Notice
    public static partial class AppErrorStatusCode
    {
        public static readonly int API_ERROR_INSTITUTION_NOT_FOUND = 1001;

    }
    public static partial class AppPendingStatusCode
    {
        public static readonly int API_PENDING_TRANSACTION = 20;
      
    }
    public static partial class AppRejectedStatusCode
    {
        public static readonly int API_REJECTED_TRANSACTION = 30;
          public static readonly int API_REJECTED_INSUFFECIENT_BALANCE = 31;
    }
}
