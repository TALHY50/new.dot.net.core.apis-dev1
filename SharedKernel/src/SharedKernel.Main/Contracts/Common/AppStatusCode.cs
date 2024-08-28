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

        // addded by mahmud
        public const int API_ERROR_QUOTATIION_NOT_FOUND = 1002;

    }
}
