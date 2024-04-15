using DotNetEnv;
using SharedLibrary.Models;
using SharedLibrary.Utilities;

namespace SharedLibrary.Constants
{
   
    public static partial class Constants
    {
        public const string COMMON_ADMIN_URL_SLUG = "5f4bff010a5ce7ebae32dc89088cb59b";

        public const string TEST_KEY = "test value";

        public static class CurlOptionTypes
        {
            public const int CURLOPT_CUSTOMREQUEST = 10036;
            public const int CURLOPT_CONNECTTIMEOUT = 78;
            public const int CURLOPT_TIMEOUT = 13;
            public const int CURLOPT_RETURNTRANSFER = 19913;
            public const int CURLOPT_HTTPHEADER = 10023;
            public const int CURLOPT_POSTFIELDS = 10015;

            public const int CURLOPT_SSL_VERIFYHOST = 81;
            public const int CURLOPT_SSL_VERIFYPEER = 64;
        }

        public static readonly string[] SYSTEM_SUPPORTED_LANGUAGE = { "en", "tr", "lt", "es" };

        
        public const string SAVEDCARD = "Saved Card";
        public const string FASTPAY_WALLET = "Fastpay Wallet";
        public const string DEFAULT_REFUND_WEB_HOOK = "DEFAULT_REFUND_WEB_HOOK";


        public const string FLOAT_NUMBER_PATTER = @"[0-9]+([\.][0-9]{1,})?";

        public static readonly Dictionary<string, string> SETTLEMENT_CODE = new Dictionary<string, string>
        {
            { "daily", "Daily" },
            { "weekly", "Weekly" },
            { "biweekly", "Bi-Weekly" },
            { "monthly", "Monthly" },
            { "bimonthly", "Bi-Monthly" },
            { "custom", "Custom" }
        };

      

        public const string PRE_AUTHORIZATION = "Pre-Authorization";
        public const int PAYMENT_BRANDED_GATE = 1;
        public const int PAYMENT_WHITE_LABEL_API_GATE = 2;
        public const int PAYMENT_DEPOSIT_GATE = 3;

       

        public static readonly string[] EMERGENCY_NOTIFICATION_EMAILS =
        {
            "rajibcuetcse@gmail.com",
            "emo.hussain1111@gmail.com",
            "galib@softrobotics.lt",
            "rifatsimoomchy@gmail.com"
        };


        public static readonly string BRAND_SECRET_KEY = Env.GetString("BRAND_SECRET_KEY", "@hnis!hsk@nos");
        //public static readonly string BRAND_SECRET_KEY = "@hnis!hsk@nos";
        


    }
}