using System.Reflection.Metadata;

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
        public static readonly int API_ERROR_RECORD_NOT_FOUND = 1001;
    }
    //Success,Error,Warning,Notice
    public static partial class AppErrorStatusCode
    {
        public static readonly int API_ERROR_RECORD_NOT_FOUND = 1001;
        public static readonly int API_ERROR_METHOD_NOT_FOUND = 1002;
        public static readonly int API_ERROR_CLASS_NOT_FOUND = 1003;
        public static readonly int API_ERROR_INVALID_DATE_RANGE = 1004;
        public static readonly int API_ERROR_TOKEN_IS_INVALID = 1005;
        public static readonly int API_ERROR_INSUFFICIENT_BALANCE = 1006;
        public static readonly int API_ERROR_FILE_MAX_LIMIT_EXCEED = 1007;
        public static readonly int API_ERROR_INVALID_FILE_FORMAT = 1008;
        public static readonly int API_ERROR_INVALID_API_REQUEST = 1009;
        public static readonly int API_ERROR_CURRENCY_IS_NOT_SUPPORTED = 1010;
        public static readonly int API_ERROR_TRANSACTION_TYPE_IS_NOT_SUPPORTED = 1011;
        public static readonly int API_ERROR_PAYMENT_METHOD_IS_NOT_SUPPORTED = 1012;
        public static readonly int API_ERROR_CARD_EXPIRED = 1013;
        public static readonly int API_ERROR_TOO_MANY_REQUESTS = 1014;
        public static readonly int API_ERROR_TRANSACTION_LIMIT_EXCEED = 1015;
        public static readonly int API_ERROR_INVALID_ACCOUNT = 1016;
        public static readonly int API_ERROR_ZIP_CODE_IS_MISSING_OR_INVALID = 1017;
        public static readonly int API_ERROR_PHONE_IS_MISSING_OR_INVALID = 1018;
        public static readonly int API_ERROR_EMAIL_IS_MISSING_OR_INVALID = 1019;
        public static readonly int API_ERROR_FIRST_NAME_IS_MISSING_OR_INVALID = 1020;
        public static readonly int API_ERROR_LAST_NAME_IS_MISSING_OR_INVALID = 1021;
        public static readonly int API_ERROR_ADDRESS1_IS_MISSING_OR_INVALID = 1022;
        public static readonly int API_ERROR_ADDRESS2_IS_MISSING_OR_INVALID = 1023;
        public static readonly int API_ERROR_ADDRESS_VERIFICATION_FAILED = 1024;
        public static readonly int API_ERROR_PHONE_VERIFICATION_FAILED = 1025;
        public static readonly int API_ERROR_EMAIL_VERIFICATION_FAILED = 1026;
        public static readonly int API_ERROR_INVALID_AMOUNT = 1027;
        public static readonly int API_ERROR_INSTITUTION_IS_NOT_ACTIVE_YET = 1028;
        public static readonly int API_ERROR_INSTITUTION_ACCOUNT_BLOCKED_OR_RESTRICTED = 1029;
        public static readonly int API_ERROR_INSTITUTION_ACCOUNT_INVALID = 1030;
        public static readonly int API_ERROR_INSTITUTION_ACCOUNT_EXPIRED = 1031;
        public static readonly int API_ERROR_INSTITUTION_AUTHORIZATION_FAILED = 1032;
        public static readonly int API_ERROR_PAYMENT_METHOD_IS_NOT_ACTIVATED = 1033;
        public static readonly int API_ERROR_INSTITUTION_ACCOUNT_IS_IN_TEST_MODE = 1034;
        public static readonly int API_ERROR_INSTITUTION_ACCOUNT_DOES_NOT_MATCH_CURRENCY = 1035;
        public static readonly int API_ERROR_COULD_NOT_CONNECT_TO_PAYMENT_PROVIDER = 1036;
        public static readonly int API_ERROR_INPUT_PARAMETER_INVALID = 1037;
    }
    public static partial class AppPendingStatusCode
    {
        public static readonly int API_PENDING_TRANSACTION = 20;
      
        // addded by mahmud
        public const int API_ERROR_QUOTATIION_NOT_FOUND = 1002;

    }
    public static partial class AppRejectedStatusCode
    {
        public static readonly int API_REJECTED_TRANSACTION = 30;
          public static readonly int API_REJECTED_INSUFFECIENT_BALANCE = 31;
    }
}
