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

    public static partial class AppServerStatusCode
    {
        public static readonly int SERVER_STATUS_CODE_CONTINUE = 100;
        public static readonly int SERVER_STATUS_CODE_SWITCHING_PROTOCOLS = 101;
        public static readonly int SERVER_STATUS_CODE_PROCESSING = 102;
        public static readonly int SERVER_STATUS_CODE_EARLY_HINTS = 103;
        public static readonly int SERVER_STATUS_CODE_OK = 200;
        public static readonly int SERVER_STATUS_CODE_CREATED = 201;
        public static readonly int SERVER_STATUS_CODE_ACCEPTED = 202;
        public static readonly int SERVER_STATUS_CODE_NON_AUTHORITATIVE_INFORMATION = 203;
        public static readonly int SERVER_STATUS_CODE_NO_CONTENT = 204;
        public static readonly int SERVER_STATUS_CODE_RESET_CONTENT = 205;
        public static readonly int SERVER_STATUS_CODE_PARTIAL_CONTENT = 206;
        public static readonly int SERVER_STATUS_CODE_MULTI_STATUS = 207;
        public static readonly int SERVER_STATUS_CODE_ALREADY_REPORTED = 208;
        public static readonly int SERVER_STATUS_CODE_IM_USED = 226;
        public static readonly int SERVER_STATUS_CODE_MULTIPLE_CHOICES = 300;
        public static readonly int SERVER_STATUS_CODE_MOVED_PERMANENTLY = 301;
        public static readonly int SERVER_STATUS_CODE_FOUND = 302;
        public static readonly int SERVER_STATUS_CODE_SEE_OTHER = 303;
        public static readonly int SERVER_STATUS_CODE_NOT_MODIFIED = 304;
        public static readonly int SERVER_STATUS_CODE_USE_PROXY = 305;
        public static readonly int SERVER_STATUS_CODE_UNUSED = 306;
        public static readonly int SERVER_STATUS_CODE_TEMPORARY_REDIRECT = 307;
        public static readonly int SERVER_STATUS_CODE_PERMANENT_REDIRECT = 308;
        public static readonly int SERVER_STATUS_CODE_BAD_REQUEST = 400;
        public static readonly int SERVER_STATUS_CODE_UNAUTHORIZED = 401;
        public static readonly int SERVER_STATUS_CODE_PAYMENT_REQUIRED = 402;
        public static readonly int SERVER_STATUS_CODE_FORBIDDEN = 403;
        public static readonly int SERVER_STATUS_CODE_NOT_FOUND = 404;
        public static readonly int SERVER_STATUS_CODE_METHOD_NOT_ALLOWED = 405;
        public static readonly int SERVER_STATUS_CODE_NOT_ACCEPTABLE = 406;
        public static readonly int SERVER_STATUS_CODE_PROXY_AUTHENTICATION_REQUIRED = 407;
        public static readonly int SERVER_STATUS_CODE_REQUEST_TIMEOUT = 408;
        public static readonly int SERVER_STATUS_CODE_CONFLICT = 409;
        public static readonly int SERVER_STATUS_CODE_GONE = 410;
        public static readonly int SERVER_STATUS_CODE_LENGTH_REQUIRED = 411;
        public static readonly int SERVER_STATUS_CODE_PRECONDITION_FAILED = 412;
        public static readonly int SERVER_STATUS_CODE_REQUEST_ENTITY_TOO_LARGE = 413;
        public static readonly int SERVER_STATUS_CODE_URI_TOO_LONG = 414;
        public static readonly int SERVER_STATUS_CODE_UNSUPPORTED_MEDIA_TYPE = 415;
        public static readonly int SERVER_STATUS_CODE_RANGE_NOT_SATISFIABLE = 416;
        public static readonly int SERVER_STATUS_CODE_EXPECTATION_FAILED = 417;
        public static readonly int SERVER_STATUS_CODE_MISDIRECTED_REQUEST = 421;
        public static readonly int SERVER_STATUS_CODE_UNPROCESSABLE_ENTITY = 422;
        public static readonly int SERVER_STATUS_CODE_LOCKED = 423;
        public static readonly int SERVER_STATUS_CODE_FAILED_DEPENDENCY = 424;
        public static readonly int SERVER_STATUS_CODE_TOO_EARLY = 425;
        public static readonly int SERVER_STATUS_CODE_UPGRADE_REQUIRED = 426;
        public static readonly int SERVER_STATUS_CODE_PRECONDITION_REQUIRED = 428;
        public static readonly int SERVER_STATUS_CODE_TOO_MANY_REQUESTS = 429;
        public static readonly int SERVER_STATUS_CODE_REQUEST_HEADERS_TOO_LARGE = 431;
        public static readonly int SERVER_STATUS_CODE_UNAVAILABLE_DUE_TO_LEGAL_REASONS = 451;
        public static readonly int SERVER_STATUS_CODE_INTERNAL_SERVER_ERROR = 500;
        public static readonly int SERVER_STATUS_CODE_NOT_IMPLEMENTED = 501;
        public static readonly int SERVER_STATUS_CODE_BAD_GATEWAY = 502;
        public static readonly int SERVER_STATUS_CODE_SERVICE_UNAVAILABLE = 503;
        public static readonly int SERVER_STATUS_CODE_GATEWAY_TIMEOUT = 504;
        public static readonly int SERVER_STATUS_CODE_HTTP_VERSION_NOT_SUPPORTED = 505;
        public static readonly int SERVER_STATUS_CODE_VARIANT_ALSO_NEGOTIATES = 506;
        public static readonly int SERVER_STATUS_CODE_INSUFFICIENT_STORAGE = 507;
        public static readonly int SERVER_STATUS_CODE_LOOP_DETECTED = 508;
        public static readonly int SERVER_STATUS_CODE_NOT_EXTENDED = 510;
        public static readonly int SERVER_STATUS_CODE_NETWORK_AUTHORIZATION_REQUIRED = 511;
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
