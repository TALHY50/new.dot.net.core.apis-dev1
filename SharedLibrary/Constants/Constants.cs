using DotNetEnv;
using SharedLibrary.Models;
using SharedLibrary.Utilities;

namespace SharedLibrary.Constants
{
    public class PaymentTypes
    {
        public const string CREDIT_CARD_PAYMENT = "C10";
        public const string MOBILE_PAYMENT = "M10";
        public const string WALLET_PAYMENT = "W10";
        public const string DEPOSIT_EFT = "B11";
        public const string DEPOSIT_CREDIT_CARD = "C11";
        public const string DEPOSIT_MERCHANT = "M11";
        public const string USER_WITHDRAWALS = "U12";
        public const string MERCHANT_WITHDRAWALS = "M12";
        public const string B2C_WALLET = "W13";
        public const string B2C_BANK = "B13";
        public const string B2B_MONEY_TRANSFER = "B14";
        public const string C2C_MONEY_TRANSFER = "C14";
        public const string EXCHANGE_TRY_TO_USD = "TU15";
        public const string EXCHANGE_TRY_TO_EUR = "TE15";
        public const string EXCHANGE_USD_TO_TRY = "UT15";
        public const string EXCHANGE_USD_TO_EUR = "UE15";
        public const string EXCHANGE_EUR_TO_TRY = "ET15";
        public const string EXCHANGE_EUR_TO_USD = "EU15";
        public const string REQUEST_MONEY = "RM10";
    }

    public static partial class Constants
    {
        public const string COMMON_ADMIN_URL_SLUG = "5f4bff010a5ce7ebae32dc89088cb59b";

        public const string TEST_KEY = "test value";

        public static class PaymentProvider
        {
            public const string WIRECARD = "WIRECARD";
            public const string PAYTEN = "PAYTEN";
            public const string NESTPAY = "NESTPAY";
            public const string DENIZ_PTT = "DENIZ_PTT";
            public const string VAKIF = "VAKIF";
            public const string ESNEKPOS = "ESNEKPOS";
            public const string ALBARAKA = "ALBARAKA";
            public const string MSU = "MSU";
            public const string TURKPOS = "TURKPOS";
            public const string YAPI_VE_KREDI = "YAPI_VE_KREDI";
            public const string TURKISH_BANK = "TURKISH_BANK";
            public const string TURK_EKONOMI = "TURK_EKONOMI";
            public const string ALTERNATIF_BANK = "ALTERNATIF_BANK";
            public const string BURGAN_BANK = "BURGAN_BANK";
            public const string ICBC_TURKEY_BANK = "ICBC_TURKEY_BANK";
            public const string QNB_FINANSBANK = "QNB_FINANSBANK";
            public const string TURKLAND_BANK = "TURKLAND_BANK";
            public const string T_GARANTI = "T_GARANTI";
            public const string KUVEYT_TURK_KATILIM = "KUVEYT_TURK_KATILIM";
            public const string PAYALL = "PAYALL";
            public const string DUMMY_PAYMENT = "DUMMY_PAYMENT";
            public const string PAYMIX = "PAYMIX";
            public const string CRAFT_GATE = "CRAFT_GATE";
            public const string SOFTROBOTICS = "SOFTROBOTICS";
            public const string TEQPAY = "TEQPAY";
            public const string MAGNET = "MAGNET";
            public const string PAVO = "PAVO";
            public const string QIWI = "QIWI";
            public const string SOFTROBOTICS_TENANT = "SOFTROBOTICS_TENANT";
        }

        public static class MerchantConfig
        {
            public const string EVENT_DUPLICATE_INVOICE = "duplicate_invoice";
            public const string EVENT_IMMEDIATE_REFUND = "immediate_refund";
            public const string EVENT_SALE_ALERT_IGNORE = "sale_alert_ignore";
        }



        public static class BankCodes
        {
            public const string VakifBank = "vakifbank";
            public const string Akbank = "akbank";
            public const string AnadoluBank = "anadolubank";
            public const string DenizBank = "denizbank";
            public const string Hsbc = "hsbc";
            public const string FinansBank = "finansbank";
            public const string Isbank = "isbank";
            public const string TurkiyeFinans = "turkiye_finans";
            public const string Albaraka = "albaraka";
            public const string Esnekpos = "esnekpos";
            public const string IngBank = "ingbank";
            public const string Citibank = "citibank";
            public const string Ziraat = "ziraat";
            public const string Halkbank = "halkbank";
            public const string Msu = "msu";
            public const string Turkpos = "turkpos";
            public const string YapiVeKredi = "yapi_ve_kredi";
            public const string Fiba = "fiba";
            public const string Sekerbank = "sekerbank";
            public const string TurkishBank = "turkish_bank";
            public const string TurkEkonomi = "turk_ekonomi";
            public const string AlternatifBank = "alternatif_bank";
            public const string BurganBank = "burgan_bank";
            public const string IcbcTurkeyBank = "icbc_turkey_bank";
            public const string OdeaBank = "odea_bank";
            public const string Qnb = "qnb_";
            public const string TurklandBank = "turkland_bank";
            public const string TGaranti = "t_garanti";
            public const string KuveytTurkKatilim = "kuveyt_turk_katilim";
            public const string Payall = "payall";
            public const string TFKBWeekly = "tfkb_weekly";
            public const string DummyBankCode = "dummy_bank_code";
            public const string Paymix = "paymix";
            public const string CraftGate = "craft_gate";
            public const string Paybull = "paybull";
            public const string Sipay = "Sipay";
            public const string Teqpay = "teqpay";
            public const string Safe2pay = "safe2pay";
            public const string Yigim = "yigim";
            public const string Qiwi = "qiwi";
            public const string EmlakBank = "emlak_bank";
        }
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

        public static List<Currency> SYSTEM_SUPPORTED_CURRENCIES
        {
            get
            {
                ApplicationDbContext Context = new ApplicationDbContext();
                return Context.Currencies.ToList();
            }
        }

        public static readonly Dictionary<string, int> MATURITY_PERIOD = new Dictionary<string, int>
        {
            { "MIN", 0 },
            { "MAX", 300 }
        };

        public static readonly Dictionary<string, int> CARD_TYPE = new Dictionary<string, int>
        {
            { "VISA", 1 },
            { "MASTER", 2 },
            { "AMEX", 3 },
            { "DINERS", 4 },
            { "DISCOVER", 5 },
            { "JCB", 6 },
            { "ANY", 7 }
        };

        //TODO:
        public static class TransactionType
        {
            public static string Withdrawal { get; } = "App\\Models\\Withdrawal";
            public static string Send { get; } = "App\\Models\\Send";
            public static string Sale { get; } = "App\\Models\\Sale";
            public static string Receive { get; } = "App\\Models\\Receive";
            public static string Purchase { get; } = "App\\Models\\Purchase";
            public static string Deposit { get; } = "App\\Models\\Deposit";
            public static string Cashout { get; } = "App\\Models\\Cashout";
            public static string Exchange { get; } = "App\\Model\\Exchange";
            public static string Others { get; } = "APP\\Models\\Others";
            public static string Refund { get; } = "App\\Models\\Refund";
            public static string Chargeback { get; } = "App\\Models\\Chargeback";
            public static string Paidbill { get; } = "App\\Models\\PaidBill";
        }


        public static readonly string ENCRYPTION_FIXED_IV = Env.GetString("ENCRYPTION_FIXED_IV");
        public static readonly string ENCRYPTION_FIXED_SALT = Env.GetString("ENCRYPTION_FIXED_SALT");
        public static readonly string CASHOUT_FINFLOW_USERNAME = Env.GetString("CASHOUT_FINFLOW_USERNAME");
        public static readonly string CASHOUT_FINFLOW_PASSWORD = Env.GetString("CASHOUT_FINFLOW_PASSWORD");
        public static readonly string CASHOUT_KKB_USERNAME = Env.GetString("CASHOUT_KKB_USERNAME");
        public static readonly string CASHOUT_KKB_PASSWORD = Env.GetString("CASHOUT_KKB_PASSWORD");
        public static readonly string WALLETGATE_API_HOST_URL = Env.GetString("WALLETGATE_API_HOST_URL");
        public static readonly string WALLETGATE_TOKEN_HOST_URL = Env.GetString("WALLETGATE_TOKEN_HOST_URL");
        public static readonly string WALLETGATE_CLIENT_ID = Env.GetString("WALLETGATE_CLIENT_ID");
        public static readonly string WALLETGATE_CLIENT_SECRET = Env.GetString("WALLETGATE_CLIENT_SECRET");
        public static readonly string WALLETGATE_TENANT_ID = Env.GetString("WALLETGATE_TENANT_ID");
        public static readonly string WALLETGATE_PRODUCT_CODE = Env.GetString("WALLETGATE_PRODUCT_CODE");
        public const string SAVEDCARD = "Saved Card";
        public const string FASTPAY_WALLET = "Fastpay Wallet";
        public const string DEFAULT_REFUND_WEB_HOOK = "DEFAULT_REFUND_WEB_HOOK";
        public static readonly string BANK_INSURANCE_TAX_DIVIDEND = Env.GetString("BANK_INSURANCE_TAX_DIVIDEND");
        public static readonly string BANK_INSURANCE_TAX_MULTIPLIER = Env.GetString("BANK_INSURANCE_TAX_MULTIPLIER");


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

        public static readonly int PASSWORD_CHANGE_AFTER_MONTHS = Env.GetInt("PASSWORD_CHANGE_AFTER_MONTHS", 0);
        public static readonly int PASSWORD_DENY_LAST_USED = Env.GetInt("PASSWORD_DENY_LAST_USED", 3);
        public static readonly int PASSWORD_SECURITY_TYPE = Env.GetInt("PASSWORD_SECURITY_TYPE", 2);

        public const string PRE_AUTHORIZATION = "Pre-Authorization";
        public const int PAYMENT_BRANDED_GATE = 1;
        public const int PAYMENT_WHITE_LABEL_API_GATE = 2;
        public const int PAYMENT_DEPOSIT_GATE = 3;


        public static readonly Dictionary<string, string> BRAND_NAME_CODE_LIST = new Dictionary<string, string>
        {
            { "BP", "BP" },
            { "DP", "DP" },
            { "EP", "EP" },
            { "FL", "FL" },
            { "FP", "FP" },
            { "IM", "IM" },
            { "PB", "PB" },
            { "PN", "PN" },
            { "SP", "SP" },
            { "VP", "VP" },
            { "SR", "SR" },
            { "AP", "AP" },
            { "PP", "PP" },
            { "MP", "MP" },
            { "YP", "YP" },
            { "QP", "QP" },
            { "QP_TENANT", "QP_TENANT" },
            { "SD", "SD" },
            { "PL", "PL" },
            { "PC", "PC" },
            { "HP", "HP" },
            { "MOP", "MOP" }
        };

        public static readonly Dictionary<string, string> SMS_PROVIDER_NAMES = new Dictionary<string, string>
        {
            { "MOBILISIM", "MOBILISIM" },
            { "CODEC", "CODEC" },
            { "ISOBIL", "ISOBIL" },
            { "VERIMOR", "VERIMOR" },
            { "PISANO", "PISANO" },
            { "JETSMS", "JETSMS" },
            { "POSTAGUVERCINI", "POSTAGUVERCINI" },
            { "CODEC_PLUS", "CODEC_PLUS" }
        };

        public static readonly string USER_VERIFICATION_BASIC_USERNAME = Env.GetString("USER_VERIFICATION_BASIC_USERNAME");
        public static readonly string USER_VERIFICATION_BASIC_PASSWORD = Env.GetString("USER_VERIFICATION_BASIC_PASSWORD");
        public static readonly string BASIC_AUTH_USER = Env.GetString("BASIC_AUTH_USER");
        public static readonly string BASIC_AUTH_PSWD = Env.GetString("BASIC_AUTH_PSWD");
        public static readonly string APP_ENVIRONMENT = Env.GetString("APP_ENV");
        public static readonly string GOOGLE_RECAPTCHA_PUBLIC_KEY = Env.GetString("GOOGLE_RECAPTCHA_PUBLIC_KEY");
        public static readonly string GOOGLE_RECAPTCHA_PRIVATE_KEY = Env.GetString("GOOGLE_RECAPTCHA_PRIVATE_KEY");
        public static readonly int IS_ENABLE_CUSTOM_DIGIT_BIN = Env.GetInt("IS_ENABLE_CUSTOM_DIGIT_BIN", 0);
        public static readonly int CUSTOM_DIGIT_BIN = Env.GetInt("CUSTOM_DIGIT_BIN", 6);
        public static readonly string APP_DOMAIN = Env.GetString("APP_DOMAIN", "");
        public static readonly string APP_URL = Env.GetString("APP_URL", "");
        public static readonly string APP_ADMIN_DOMAIN = string.Concat(Env.GetString("APP_DOMAIN", ""), "/admin/", COMMON_ADMIN_URL_SLUG);
        public static readonly string APP_MERCHANT_DOMAIN = string.Concat(Env.GetString("APP_DOMAIN", ""), "/merchant");
        public static readonly string APP_CCPAYMENT_DOMAIN = string.Concat(Env.GetString("APP_DOMAIN", ""), "/ccpayment");
        public static readonly string MERCHANT_APPLICATION_FRONTEND_URL = Env.GetString("MERCHANT_APPLICATION_FRONTEND_URL", "");
        public static readonly string SALE_INFO_OUT_GOING_DB_DRIVER = Env.GetString("SALE_INFO_OUT_GOING_DB_DRIVER", "");
        public static readonly string SALE_INFO_OUT_GOING_DB_HOST = Env.GetString("SALE_INFO_OUT_GOING_DB_HOST", "");
        public static readonly string SALE_INFO_OUT_GOING_DB_PORT = Env.GetString("SALE_INFO_OUT_GOING_DB_PORT", "");
        public static readonly string SALE_INFO_OUT_GOING_DB_DATABASE = Env.GetString("SALE_INFO_OUT_GOING_DB_DATABASE", "");
        public static readonly string SALE_INFO_OUT_GOING_DB_USERNAME = Env.GetString("SALE_INFO_OUT_GOING_DB_USERNAME", "");
        public static readonly string SALE_INFO_OUT_GOING_DB_PASSWORD = Env.GetString("SALE_INFO_OUT_GOING_DB_PASSWORD", "");
        public static readonly string LICENSE_OWNER_URL = Env.GetString("LICENSE_OWNER_URL", "");
        public static readonly string LICENSE_OWNER_NAME = Env.GetString("LICENSE_OWNER_NAME", "");
        public static readonly string MT940_SFTP_HOST = Env.GetString("MT940_SFTP_HOST");
        public static readonly string MT940_SFTP_USERNAME = Env.GetString("MT940_SFTP_USERNAME");
        public static readonly string MT940_SFTP_PASSWORD = Env.GetString("MT940_SFTP_PASSWORD");
        public static readonly string MT940_SFTP_PORT = Env.GetString("MT940_SFTP_PORT");
        public static readonly string MT940_SFTP_ROOT_PATH = Env.GetString("MT940_SFTP_ROOT_PATH");

        public static readonly string[] EMERGENCY_NOTIFICATION_EMAILS =
        {
            "rajibcuetcse@gmail.com",
            "emo.hussain1111@gmail.com",
            "galib@softrobotics.lt",
            "rifatsimoomchy@gmail.com"
        };


        public static readonly string MAX_OTP_RESEND_LIMIT = Env.GetString("MAX_OTP_RESEND_LIMIT");
        public static readonly string MAX_OTP_FAILED_ATTEMPT = Env.GetString("MAX_OTP_FAILED_ATTEMPT");
        public static readonly string FCM_SERVER_KEY = Env.GetString("FCM_SERVER_KEY", "");
        public static readonly string HMS_APP_ID = Env.GetString("HMS_APP_ID");
        public static readonly string HMS_SERVER_KEY = Env.GetString("HMS_SERVER_KEY");
        public static readonly string SMS_VERIFICATION_HASH = Env.GetString("SMS_VERIFICATION_HASH", "");
        public static readonly string SUPPORT_EMAIL_ADDRESS = Env.GetString("SUPPORT_EMAIL_ADDRESS", "");
        public static readonly string OTP_SEND_URL = Env.GetString("OTP_SEND_URL", "");
        public static readonly string IKS_SERVICE_ADDRESS = Env.GetString("IKS_SERVICE_ADDRESS", "");
        public static readonly string IKS_CLIENT_ID = Env.GetString("IKS_CLIENT_ID", "");
        public static readonly string IKS_CLIENT_SECRET = Env.GetString("IKS_CLIENT_SECRET", "");
        public static readonly string EXTERNAL_CERTIFICATE_PATH = Env.GetString("EXTERNAL_CERTIFICATE_PATH", "");
        public static readonly string OTP_FROM_CODE = Env.GetString("OTP_FROM_CODE", "");
        public static readonly string BRAND_CENTRAL_BANK_CODE = Env.GetString("BRAND_CENTRAL_BANK_CODE", "");
        public static readonly string BTRANS_HOST = Env.GetString("BTRANS_HOST", "");
        public static readonly string BTRANS_PORT = Env.GetString("BTRANS_PORT", "");
        public static readonly string BTRANS_USER_NAME = Env.GetString("BTRANS_USER_NAME", "");
        public static readonly string BTRANS_PASSWORD = Env.GetString("BTRANS_PASSWORD", "");
        public static readonly string BTRANS_DIRECTORY = Env.GetString("BTRANS_DIRECTORY", "");
        public static readonly string CARD_API_BASE_URL = Env.GetString("CARD_API_BASE_URL", "");
        public static readonly string CARD_API_ACCOUNT_BASE_URL = Env.GetString("CARD_API_ACCOUNT_BASE_URL", "");
        public static readonly string CARD_API_USERNAME = Env.GetString("CARD_API_USERNAME", "");
        public static readonly string CARD_API_PASSWORD = Env.GetString("CARD_API_PASSWORD", "");
        public static readonly string CARD_API_TENANT_CODE = Env.GetString("CARD_API_TENANT_CODE", "");
        public static readonly string CARD_API_VIRTUAL_PRODUCT_CODE = Env.GetString("CARD_API_VIRTUAL_PRODUCT_CODE", "");
        public static readonly string CARD_API_PYHSICAL_PRODUCT_CODE = Env.GetString("CARD_API_PYHSICAL_PRODUCT_CODE", "");
        public static readonly string CARD_API_KEY = Env.GetString("CARD_API_KEY", "");
        public static readonly string FINFLOW_HOST_URL = Env.GetString("FINFLOW_HOST_URL", "");
        public const string FINFLOW_BASIC_AUTH_ALLOW = "FINFLOW_BASIC_AUTH";
        public static readonly string KKB_REQUEST_URL = Env.GetString("KKB_REQUEST_URL", "");
        private static readonly Dictionary<string, Dictionary<string, string>> SubMerchantInfos =
            new Dictionary<string, Dictionary<string, string>>
            {
                {
                    "SP", new Dictionary<string, string>
                    {
                        { "ID", "98950" },
                        { "NAME", Env.GetString("BRAND_NAME") },
                        { "NIN", "7710528103" },
                        { "MCC", "6012" },
                        { "POSTAL_CODE", "34662" },
                        { "ISO_COUNTRY_CODE", "792" },
                        { "CITY", "İstanbul" },
                        { "SITE_URL", "https://sipay.com.tr" },
                        { "VISA_SUB_MERCHANT_ID", "20000012" },
                        { "VISA_PF_ID", "10083599" },
                        { "VISA_MRC_PF_ID", "20000012" },
                        { "COMPANY_CODE", "KK048" }
                    }
                },
                {
                    "SR", new Dictionary<string, string>
                    {
                        { "ID", "98950" },
                        { "NAME", Env.GetString("BRAND_NAME") },
                        { "NIN", "7710528103" },
                        { "MCC", "6012" },
                        { "POSTAL_CODE", "34662" },
                        { "ISO_COUNTRY_CODE", "792" },
                        { "CITY", "İstanbul" },
                        { "SITE_URL", "https://sipay.com.tr" },
                        { "VISA_SUB_MERCHANT_ID", "20000012" },
                        { "VISA_PF_ID", "10083599" },
                        { "VISA_MRC_PF_ID", "20000012" },
                        { "COMPANY_CODE", "KK048" }
                    }
                },
                {
                    "PB", new Dictionary<string, string>
                    {
                        { "ID", "98950" },
                        { "NAME", Env.GetString("BRAND_NAME") },
                        { "NIN", "8710528103" },
                        { "MCC", "7012" },
                        { "POSTAL_CODE", "44662" },
                        { "ISO_COUNTRY_CODE", "792" },
                        { "CITY", "İstanbul" },
                        { "SITE_URL", "https://paybull.com.tr" },
                        { "VISA_SUB_MERCHANT_ID", "97570982" },
                        { "VISA_PF_ID", "20020562" },
                        { "VISA_MRC_PF_ID", "10000033" }
                    }
                },
                {
                    "PN", new Dictionary<string, string>
                    {
                        { "ID", "98950" },
                        { "NAME", Env.GetString("BRAND_NAME") },
                        { "NIN", "8710528103" },
                        { "MCC", "7012" },
                        { "POSTAL_CODE", "44662" },
                        { "ISO_COUNTRY_CODE", "792" },
                        { "CITY", "İstanbul" },
                        { "SITE_URL", "https://payneer.com.tr" },
                        { "VISA_SUB_MERCHANT_ID", "97570982" },
                        { "VISA_PF_ID", "20020562" },
                        { "VISA_MRC_PF_ID", "30000012" }
                    }
                },
                {
                    "FL", new Dictionary<string, string>
                    {
                        { "ID", "98950" },
                        { "NAME", Env.GetString("BRAND_NAME") },
                        { "NIN", "8710528103" },
                        { "MCC", "7012" },
                        { "POSTAL_CODE", "44662" },
                        { "ISO_COUNTRY_CODE", "792" },
                        { "CITY", "İstanbul" },
                        { "SITE_URL", "https://fintlix.com.tr" },
                        { "VISA_SUB_MERCHANT_ID", "97570982" },
                        { "VISA_PF_ID", "20020562" },
                        { "VISA_MRC_PF_ID", "30000012" }
                    }
                },
                {
                    "VP", new Dictionary<string, string>
                    {
                        { "ID", "98950" },
                        { "NAME", Env.GetString("BRAND_NAME") },
                        { "NIN", "8710528103" },
                        { "MCC", "7012" },
                        { "POSTAL_CODE", "44662" },
                        { "ISO_COUNTRY_CODE", "792" },
                        { "CITY", "İstanbul" },
                        { "SITE_URL", "https://vepara.com.tr" },
                        { "VISA_SUB_MERCHANT_ID", "97570982" },
                        { "VISA_PF_ID", "20020562" },
                        { "VISA_MRC_PF_ID", "30000012" }
                    }
                },
                {
                    "FP", new Dictionary<string, string>
                    {
                        { "ID", "98950" },
                        { "NAME", Env.GetString("BRAND_NAME") },
                        { "NIN", "5920296598" },
                        { "MCC", "7552" },
                        { "POSTAL_CODE", "34394" },
                        { "ISO_COUNTRY_CODE", "792" },
                        { "CITY", "İstanbul" },
                        { "SITE_URL", "https://fastpay.com.tr" },
                        { "VISA_SUB_MERCHANT_ID", "97570982" },
                        { "VISA_PF_ID", "20020562" },
                        { "VISA_MRC_PF_ID", "30000012" }
                    }
                },
                {
                    "BP", new Dictionary<string, string>
                    {
                        { "ID", "98950" },
                        { "NAME", Env.GetString("BRAND_NAME") },
                        { "NIN", "8710528103" },
                        { "MCC", "7012" },
                        { "POSTAL_CODE", "44662" },
                        { "ISO_COUNTRY_CODE", "792" },
                        { "CITY", "İstanbul" },
                        { "SITE_URL", "https://bingopay.com.tr" },
                        { "VISA_SUB_MERCHANT_ID", "97570982" },
                        { "VISA_PF_ID", "20020562" },
                        { "VISA_MRC_PF_ID", "30000012" }
                    }
                },
                {
                    "TP", new Dictionary<string, string>
                    {
                        { "ID", "98950" },
                        { "NAME", Env.GetString("BRAND_NAME") },
                        { "NIN", "8710528103" },
                        { "MCC", "7012" },
                        { "POSTAL_CODE", "44662" },
                        { "ISO_COUNTRY_CODE", "792" },
                        { "CITY", "İstanbul" },
                        { "SITE_URL", "https://tria.com.tr" },
                        { "VISA_SUB_MERCHANT_ID", "97570982" },
                        { "VISA_PF_ID", "20020562" },
                        { "VISA_MRC_PF_ID", "30000012" }
                    }
                },
                {
                    "IM", new Dictionary<string, string>
                    {
                        { "ID", "75600" },
                        { "NAME", Env.GetString("BRAND_NAME") },
                        { "NIN", "78106052343" },
                        { "MCC", "7552" },
                        { "POSTAL_CODE", "34752" },
                        { "ISO_COUNTRY_CODE", "792" },
                        { "CITY", "İstanbul" },
                        { "SITE_URL", "https://www.iqmoney.com.tr" },
                        { "VISA_SUB_MERCHANT_ID", "" },
                        { "VISA_PF_ID", "" },
                        { "VISA_MRC_PF_ID", "" }
                    }
                },
                {
                    "PP", new Dictionary<string, string>
                    {
                        { "ID", "98950" },
                        { "NAME", Env.GetString("BRAND_NAME") },
                        { "NIN", "7210805934" },
                        { "MCC", "7552" },
                        { "POSTAL_CODE", "34307" },
                        { "ISO_COUNTRY_CODE", "792" },
                        { "CITY", "İstanbul" },
                        { "SITE_URL", "https://papel.com.tr" },
                        { "VISA_SUB_MERCHANT_ID", "" },
                        { "VISA_PF_ID", "" },
                        { "VISA_MRC_PF_ID", "" }
                    }
                }
            };


        public static class SubMerchantInfos1
        {
            public static SubMerchantInfo SP { get; } = new SubMerchantInfo
            {
                Id = "98950",
                Name = Env.GetString("BRAND_NAME"),
                Nin = "7710528103",
                Mcc = "6012",
                PostalCode = "34662",
                IsoCountryCode = "792",
                City = "İstanbul",
                SiteUrl = "https://sipay.com.tr",
                VisaSubMerchantId = "20000012",
                VisaPfId = "10083599",
                VisaMrcPfId = "20000012",
                CompanyCode = "KK048"
            };

            public static SubMerchantInfo SR { get; } = new SubMerchantInfo
            {
                Id = "98950",
                Name = Env.GetString("BRAND_NAME"),
                Nin = "7710528103",
                Mcc = "6012",
                PostalCode = "34662",
                IsoCountryCode = "792",
                City = "İstanbul",
                SiteUrl = "https://sipay.com.tr",
                VisaSubMerchantId = "20000012",
                VisaPfId = "10083599",
                VisaMrcPfId = "20000012",
                CompanyCode = "KK048"
            };

            public static SubMerchantInfo PB { get; } = new SubMerchantInfo
            {
                Id = "98950",
                Name = Env.GetString("BRAND_NAME"),
                Nin = "8710528103",
                Mcc = "7012",
                PostalCode = "44662",
                IsoCountryCode = "792",
                City = "İstanbul",
                SiteUrl = "https://paybull.com.tr",
                VisaSubMerchantId = "97570982",
                VisaPfId = "20020562",
                VisaMrcPfId = "10000033"
            };

            public static SubMerchantInfo PN { get; } = new SubMerchantInfo
            {
                Id = "98950",
                Name = Env.GetString("BRAND_NAME"),
                Nin = "8710528103",
                Mcc = "7012",
                PostalCode = "44662",
                IsoCountryCode = "792",
                City = "İstanbul",
                SiteUrl = "https://payneer.com.tr",
                VisaSubMerchantId = "97570982",
                VisaPfId = "20020562",
                VisaMrcPfId = "30000012"
            };

            public static SubMerchantInfo FL { get; } = new SubMerchantInfo
            {
                Id = "98950",
                Name = Env.GetString("BRAND_NAME"),
                Nin = "8710528103",
                Mcc = "7012",
                PostalCode = "44662",
                IsoCountryCode = "792",
                City = "İstanbul",
                SiteUrl = "https://fintlix.com.tr",
                VisaSubMerchantId = "97570982",
                VisaPfId = "20020562",
                VisaMrcPfId = "30000012"
            };

            public static SubMerchantInfo VP { get; } = new SubMerchantInfo
            {
                Id = "98950",
                Name = Env.GetString("BRAND_NAME"),
                Nin = "8710528103",
                Mcc = "7012",
                PostalCode = "44662",
                IsoCountryCode = "792",
                City = "İstanbul",
                SiteUrl = "https://vepara.com.tr",
                VisaSubMerchantId = "97570982",
                VisaPfId = "20020562",
                VisaMrcPfId = "30000012"
            };

            public static SubMerchantInfo FP { get; } = new SubMerchantInfo
            {
                Id = "98950",
                Name = Env.GetString("BRAND_NAME"),
                Nin = "5920296598",
                Mcc = "7552",
                PostalCode = "34394",
                IsoCountryCode = "792",
                City = "İstanbul",
                SiteUrl = "https://fastpay.com.tr",
                VisaSubMerchantId = "97570982",
                VisaPfId = "20020562",
                VisaMrcPfId = "30000012"
            };

            public static SubMerchantInfo BP { get; } = new SubMerchantInfo
            {
                Id = "98950",
                Name = Env.GetString("BRAND_NAME"),
                Nin = "8710528103",
                Mcc = "7012",
                PostalCode = "44662",
                IsoCountryCode = "792",
                City = "İstanbul",
                SiteUrl = "https://bingopay.com.tr",
                VisaSubMerchantId = "97570982",
                VisaPfId = "20020562",
                VisaMrcPfId = "30000012"
            };

            public static SubMerchantInfo TP { get; } = new SubMerchantInfo
            {
                Id = "98950",
                Name = Env.GetString("BRAND_NAME"),
                Nin = "8710528103",
                Mcc = "7012",
                PostalCode = "44662",
                IsoCountryCode = "792",
                City = "İstanbul",
                SiteUrl = "https://tria.com.tr",
                VisaSubMerchantId = "97570982",
                VisaPfId = "20020562",
                VisaMrcPfId = "30000012"
            };

            public static SubMerchantInfo IM { get; } = new SubMerchantInfo
            {
                Id = "75600",
                Name = Env.GetString("BRAND_NAME"),
                Nin = "78106052343",
                Mcc = "7552",
                PostalCode = "34752",
                IsoCountryCode = "792",
                City = "İstanbul",
                SiteUrl = "https://www.iqmoney.com.tr"
            };

            public static SubMerchantInfo PP { get; } = new SubMerchantInfo
            {
                Id = "98950",
                Name = Env.GetString("BRAND_NAME"),
                Nin = "7210805934",
                Mcc = "7552",
                PostalCode = "34307",
                IsoCountryCode = "792",
                City = "İstanbul",
                SiteUrl = "https://papel.com.tr"
            };
        }

        public static readonly Dictionary<string, string>? SUBMERCHANT_INFO =
            !SubMerchantInfos.ContainsKey(Env.GetString("BRAND_NAME_CODE"))
                ? null
                : SubMerchantInfos[Env.GetString("BRAND_NAME_CODE")];


        public static readonly SubMerchantInfo? SUBMERCHANT_INFO1 = (SubMerchantInfo)Search.FindPropertyValueByName(typeof(SubMerchantInfos1), Env.GetString("BRAND_NAME_CODE"));


        public static readonly bool IS_QUEUE_ENABLE = Env.GetBool("IS_QUEUE_ENABLE");
        public static readonly string OTP_GATEWAY_NAME = Env.GetString("OTP_GATEWAY_NAME");
        public static readonly string OTP_API_KEY = Env.GetString("OTP_API_KEY");
        public static readonly string MOBILE_PAYMENT_USER_PIN = Env.GetString("MOBILE_PAYMENT_USER_PIN");
        public static readonly int IS_OTP_ENABLE = Env.GetInt("IS_OTP_ENABLE", 1);
        public static readonly bool IS_INTEGRATION_FILE_WRITE_ENABLE = Env.GetBool("IS_INTEGRATION_FILE_WRITE_ENABLE");
        public static readonly string app_frontend_url = Env.GetString("APP_FRONTEND_URL", "");
        public static readonly string MAIL_FROM_ADDRESS = Env.GetString("MAIL_FROM_ADDRESS", "");
        public static readonly string APP_ADMIN_URL = Env.GetString("APP_ADMIN_URL", "");
        public static readonly string PUB_KEY_PATH = Env.GetString("PUB_KEY_PATH");
        public static readonly string WIX_PAYMENT_PROVIDER_APP_SECRET = Env.GetString("WIX_PAYMENT_PROVIDER_APP_SECRET");
        public static readonly string APP_NAME = Env.GetString("APP_NAME", "Laravel");
        public static readonly string APPLICATION_STATE = Env.GetString("APPLICATION_STATE");
        public static readonly string ADMIN_EMAIL = Env.GetString("ADMIN_EMAIL");
        public static readonly string BIN_AUTH = Env.GetString("BIN_AUTH");
        public static readonly string OTP_FROM_NAME = Env.GetString("OTP_FROM_NAME");
        public static readonly string OTP_API_SECRET = Env.GetString("OTP_API_SECRET");
        public static readonly string MOBILE_PAYMENT_USER_CODE = Env.GetString("MOBILE_PAYMENT_USER_CODE");
        public static readonly bool IS_OTP_FILE_WRITE_ENABLE = Env.GetBool("IS_OTP_FILE_WRITE_ENABLE");
        public static readonly int MINIMUM_ORDER_AMOUNT = Env.GetInt("MINIMUM_ORDER_AMOUNT", 5);
        public static readonly string SYSTEM_NO_REPLY_ADDRESS = Env.GetString("SYSTEM_NO_REPLY_ADDRESS", "");
        public static readonly string ACCOUNTANT_EMAIL = Env.GetString("ACCOUNTANT_EMAIL", "rajibcuetcse@gmail.com");
        public static readonly string BRAND_SECRET_KEY = Env.GetString("SIPAY_SECRET_KEY", "@hnis!hsk@nos");
        public static readonly string WIX_PAYMENT_PROVIDER_APP_ID = Env.GetString("WIX_PAYMENT_PROVIDER_APP_ID");
        public static readonly string TAXI_API_SERVICE_BASIC_TOKEN = Env.GetString("TAXI_API_SERVICE_BASIC_TOKEN");

        public static class ActivityTitles
        {
            public const string CreditCard = "Credit Card";
            public static string SipayWallet => string.Concat(Env.GetString("BRAND_NAME", ""), " Wallet");
            public const string MobilePayment = "Mobile Payment";
        }

        public static readonly string CARD_INFO_API_URL = Env.GetString("CARD_INFO_API_URL");
    }
}