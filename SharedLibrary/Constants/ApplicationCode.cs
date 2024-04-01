using DotNetEnv;

namespace SharedLibrary.Constants
{

    public static class ApplicationCode
    {
        public const int NO_ERROR = 0;
        public const int SUCCESS = 100;
        public const int VISA_CARD_IS_NOT_ALLOWED_FOR_THIS_MERCHANT = 1;
        public const int MASTER_CARD_IS_NOT_ALLOWED_FOR_THIS_MERCHANT = 1;
        public const int BASIC_VALIDATION = 1;
        public const int TRANSACTION_TYPE_MUST_BE_AUTH_OR_PREAUTH = 1;
        public const int BILL_PAYMENT_IS_NOT_AVAILABLE_FOR_THIS_BRAND = 1;
        public const int PREAUTH_TRANSACTION_IS_NOT_ALLOWED_FOR_RECURRING_PAYMENT = 1;
        public const int PREAUTH_TRANSACTION_IS_NOT_ALLOWED_FOR_THIS_END_POINT = 1;
        public const int THE_MERCHANT_IS_NOT_ALLOWED_TO_PREAUTH_TRANSACTION = 1;
        public const int PREAUTH_TRANSACTION_IS_NOT_ALLOWED_FOR_THIS_POS = 1;
        public const int MERCHANT_IS_NOT_ALLOWED_FOR_BILL_PAYMENT = 1;
        public const int CVV_LESS_TRANSACTION_IS_NOT_ALLOWED_FOR_THIS_MERCHANT = 1;
        public const int ONLY_CREDIT_CARD_IS_ALLOWED_FOR_PREAUTH_TRANSACTION = 1;
        public const int SUB_MERCHANTS_SETTLEMENT_ID_NOT_FOUND = 1;
        public const int INVOICE_ID_ALREADY_PROCESSED = 3;
        public const int PRICE_MUST_BE_NUMERIC_VALUE = 10;
        public const int ITEMS_MUST_BE_AN_ARRAY = 12;
        public const int INVALID_CURRENCY_CODE = 12;
        public const int CURRENCY_NOT_FOUND = 13;
        public const int INVALID_FORMAT_OF_ITEMS = 12;
        public const int THE_TOTAL_OF_THE_ITEMS_PRICE_NOT_EQUAL_TO_THE_INVOICE_TOTAL = 13;
        public const int MERCHANT_NOT_FOUND = 14;
        public const int INVALID_MERCHANT_KEY = 14;
        public const int MERCHANT_IS_NOT_A_MARKETPLACE_MERCHANT = 14;
        public const int SUB_MERCHANT_NOT_FOUND = 14;
        public const int MERCHANT_IP_IS_NOT_ALLOWED = 15;
        public const int END_USER_IP_IS_NOT_ALLOWED = 15;
        public const int INVALID_CREDENTIALS = 30;
        public const int PF_RECORDS_NOT_FOUND_WITH_THIS_MERCHANT_AND_PF_ID = 30;
        public const int TRANSACTION_NOT_FOUND = 31;
        public const int INVALID_INVOICE_ID = 32;
        public const int ORDER_NOT_COMPLETED = 32;
        public const int QUANTITY_MUST_BE_INTEGER_VALUE = 33;
        public const int THE_INSURANCE_PAYMENT_INTEGRATION_IS_NOT_ALLOWED = 34;
        public const int THE_PAYMENT_INTEGRATION_METHOD_IS_NOT_ALLOWED = 34;
        public const int CREDIT_CARD_PAYMENT_OPTION_HAS_NOT_BEEN_DEFINED = 35;
        public const int INVALID_POS_ID_DEFINED = 36;
        public const int INSTALLMENTS_NOT_ACTIVATED_FOR_THE_POS = 36;
        public const int MERCHANT_POS_COMMISSION_WAS_NOT_SET = 37;
        public const int MERCHANT_COMMISSION_WAS_NOT_SET_FOR_THIS_CURRENCY_AND_PAYMENT_METHOD = 38;
        public const int SETTLEMENT_DATE_WAS_NOT_SET = 43;
        public const int SUB_MERCHANT_CAN_NOT_HAVE_SETTLEMENT_DATE_BEFORE_MERCHANT = 43;
        public const int THIS_CREDIT_CARD_IS_BLOCKED = 44;
        public const int TENANT_MERCHANT_IS_NOT_APPROVED = 45;
        public const int POS_CURRENCY_DOES_NOT_MATCHES_WITH_EXPECTED_CURRENCY_ID = 48;
        public const int INVALID_HASH_KEY = 68;
        public const int CARD_PROGRAM_MISMATCH = 70;
        public const int FOREIGN_CARD_IS_NOT_ALLOWED_FOR_THIS_MERCHANT = 76;
        public const int FOREIGN_CARD_IS_NOT_ALLOWED_FOR_THIS_POS = 77;
        public const int FOREIGN_CARD_COMMISSION_IS_NOT_SET_FOR_THIS_MERCHANT = 77;
        public const int FOREIGN_CARD_IS_NOT_SET_FOR_THIS_MERCHANT_POS_COMMISSION = 77;
        public const int MERCHANT_IS_NOT_ALLOWED_TO_PAY_WITH_CARD_TOKEN = 78;
        public const int THE_PAYMENT_IS_NOT_WITH_MARKETPLACE_API = 79;
        public const int HASH_KEY_MICHMATCH = 90;
        public const int MERCHANT_IS_NOT_ALLOWED_FOR_PAY_BY_TOKEN = 98;
        public const int PAYBYTOKEN_COMMISSION_WAS_NOT_SETUP = 103;
        public const int CARD_NUMBER_LENGTH_MUST_BE_15_TO_16 = 108;
        public const int TOTAL_LENGTH_OF_CARD_NUMBER_AND_CVV_MUST_BE_19 = 108;
        public const int ORDER_ID_NOT_FOUND = 109;
        public const int CONTEXT_BINDING_FAILDED = 110;
        public const int PAYMENT_AUTHENTICATION_FAILURE = 111;
        public const int PAYMENT_AUTHORIZATION_FAILURE = 112;
        public const int SALE_NOT_FOUND = 113;
        public const int BANK_NOT_FOUND = 114;
        public const int TMP_BANK_RESPONSE_NOT_FOUND = 302;
        public const int COMMISSION_NOT_FOUND = 117;
        public const int TMP_PAYMENT_RECORD_NOT_FOUND = 115;
        public const int PURCHASE_REQUEST_NOT_FOUND = 116;
        public const int PAYMENT_REQUEST_NOT_FOUND = 117;
        public const int INVALID_TRANSACTION_STATE = 114;
        public const int ALREADY_PROCESSED = 15;
        public const int SETTLEMENT_NOT_FOUND = 115;
        public const int SUCCESS_SALE_EXCEPTION = 116;
        public const int FAIL_SALE_EXCEPTION = 117;
        public const int PAYMENT_FAILED = 41;
        public const int CONFIRM_PAYMENT_CONFIRMATION_FAILED = 105;
        public const int PAYMENT_FAILED_ORDER_STATUS = 32;
        public const int SYSTEM_BASED_INITIALIZATION_ERROR = 99;
        public const int POS_NOT_DEFINED = 36;
        public const int MERCHANT_POS_COMMISSION_LIST_EMPTY = 37;
        public const int MERCHANT_NOT_AUTHORIZED = 14;
        public const int MERCHANT_NOT_AUTHORIZED_FOR_PREAUTH = 16;
        public const int RESTRICTED_INVALID_IP = 15;
        public const int NON_REFUNDABLE_TRANSACION_STATE = 16;
        public const int INVALID_AMOUNT = 17;
        public const int INVALID_POST_AUTH_AMOUNT = 17;
        public const int SALS_NOT_PROCESSED = 114;
        public const int WALLET_NOT_FOUND = 2;
        public const int INSUFFICIENT_BALANCE = 3;
        public const int DUPLICATE_REFUND_REFERENCE_ID = 104;
        public const int ENTITY_NOT_FOUND = 89;
        public const int AWAITING_REFUND = 101;
        public const int REFUND_FAILED = 49;
        public const int TRANSACTION_NOT_PROCESSED_YET = 114;
        public const int REFUND_HISTORY_NOT_FOUND = 118;
        public const int MERCHANT_SALE_NOT_FOUND = 119;
        public const int REFUND_REJECTION_SUCCESS = 102;
        public const int SAVE_CARD_NOT_FOUND = 130;
        public const int SAVE_CARD_CUSTOMER_CREATION_FAILED = 144;
        public const int SAVE_CARD_ADD_CARD_FAILED = 145;
        public const int SAVE_CARD_DELETE_CARD_FAILED = 148;
        public const int SAVE_CARD_SEARCH_CARD_FAILED = 146;
        public const int SAVE_CARD_BANK_NOT_FOUND = 138;
        public const int CARD_TOKEN_BANK_NOT_FOUND = 131;
        public const int CARD_TOKEN_PROVIDER_ACCOUNT_NOT_FOUND = 106;
        public const int FAILED_TO_ACQUIRE_CARD_INFORMATION_FROM_CARD_TOKEN_PROVIDER = 107;
        public const int INVALID_PAYMENT_PROVIDER = 109;
        public const int MISMATCHED_TARIM_DATA = 110;
            


        //Messages
        public static readonly Dictionary<string, string> StatusMessageList = new Dictionary<string, string>()
        {
            {"VISA_CARD_IS_NOT_ALLOWED_FOR_THIS_MERCHANT","Visa card is not allowed for this merchant." },
            {"MASTER_CARD_IS_NOT_ALLOWED_FOR_THIS_MERCHANT","Master card is not allowed for this merchant."},
            {"BASIC_VALIDATION","Basic validation." },
            {"CVV_LESS_TRANSACTION_IS_NOT_ALLOWED_FOR_THIS_MERCHANT","cvv less transaction is not allowed for this merchant" },
            {"PREAUTH_TRANSACTION_IS_NOT_ALLOWED_FOR_THIS_END_POINT","PreAuth Transaction is not allowed for this end point" },
            {"TRANSACTION_TYPE_MUST_BE_AUTH_OR_PREAUTH","Transaction type must be Auth or PreAuth." },
            {"BILL_PAYMENT_IS_NOT_AVAILABLE_FOR_THIS_BRAND","Bill payment is not available for this brand." },
            {"PREAUTH_TRANSACTION_IS_NOT_ALLOWED_FOR_RECURRING_PAYMENT","PreAuth transaction is not allowed for recurring payment." },
            {"THE_MERCHANT_IS_NOT_ALLOWED_TO_PREAUTH_TRANSACTION","The merchant is not allowed to PreAuth transaction." },
            {"PREAUTH_TRANSACTION_IS_NOT_ALLOWED_FOR_THIS_POS","Preauth transaction is not allowed for this pos." },
            {"MERCHANT_IS_NOT_ALLOWED_FOR_BILL_PAYMENT","Merchant is not allowed for bill payment." },
            {"ONLY_CREDIT_CARD_IS_ALLOWED_FOR_PREAUTH_TRANSACTION","Only credit card is allowed for PreAuth transaction." },
            {"SUB_MERCHANTS_SETTLEMENT_ID_NOT_FOUND","Sub merchants settlement id not found." },
            {"INVOICE_ID_ALREADY_PROCESSED","Invoice id already processed." },
            {"PRICE_MUST_BE_NUMERIC_VALUE","Price must be numeric value." },
            {"ITEMS_MUST_BE_AN_ARRAY","Items must be an array." },
            {"INVALID_CURRENCY_CODE","Invalid currency code." },
            {"INVALID_FORMAT_OF_ITEMS","Invalid format of items." },
            {"THE_TOTAL_OF_THE_ITEMS_PRICE_NOT_EQUAL_TO_THE_INVOICE_TOTAL","The total of the items price not equal to the invoice total." },
            {"MERCHANT_NOT_FOUND","Merchant not found." },
            {"INVALID_MERCHANT_KEY","Invalid merchant key." },
            {"MERCHANT_IS_NOT_A_MARKETPLACE_MERCHANT","Merchant is not a marketplace merchant." },
            {"SUB_MERCHANT_NOT_FOUND","Sub merchant not found." },
            {"MERCHANT_IP_IS_NOT_ALLOWED","Merchant ip is not allowed." },
            {"END_USER_IP_IS_NOT_ALLOWED","End user ip is not allowed." },
            {"INVALID_CREDENTIALS","Invalid credentials." },
            {"PF_RECORDS_NOT_FOUND_WITH_THIS_MERCHANT_AND_PF_ID","Pf records not found with this merchant and pf id." },
            {"TRANSACTION_NOT_FOUND","Transaction not found." },
            {"INVALID_INVOICE_ID","Invalid invoice id." },
            {"ORDER_NOT_COMPLETED","Order not completed." },
            {"QUANTITY_MUST_BE_INTEGER_VALUE","Quantity must be integer value." },
            {"THE_INSURANCE_PAYMENT_INTEGRATION_IS_NOT_ALLOWED","The insurance payment integration is not allowed. Please contact support." },
            {"THE_PAYMENT_INTEGRATION_METHOD_IS_NOT_ALLOWED","The payment integration method is not allowed." },
            {"CREDIT_CARD_PAYMENT_OPTION_HAS_NOT_BEEN_DEFINED","Credit card payment option has not been defined." },
            {"INVALID_POS_ID_DEFINED","Invalid pos id defined." },
            {"INSTALLMENTS_NOT_ACTIVATED_FOR_THE_POS","Installments not activated for the pos." },
            {"MERCHANT_POS_COMMISSION_WAS_NOT_SET","Merchant pos commission was not set. Please contact support." },
            {"MERCHANT_COMMISSION_WAS_NOT_SET_FOR_THIS_CURRENCY_AND_PAYMENT_METHOD","Merchant commission was not set for this currency and payment method." },
            {"SETTLEMENT_DATE_WAS_NOT_SET","Settlement date was not set." },
            {"SUB_MERCHANT_CAN_NOT_HAVE_SETTLEMENT_DATE_BEFORE_MERCHANT","Sub merchant can not have settlement date before merchant." },
            {"THIS_CREDIT_CARD_IS_BLOCKED","This credit card is blocked." },
            {"TENANT_MERCHANT_IS_NOT_APPROVED","Tenant merchant is not approved." },
            {"POS_CURRENCY_DOES_NOT_MATCHES_WITH_EXPECTED_CURRENCY_ID","Pos currency does not matches with expected currency id." },
            {"INVALID_HASH_KEY","Invalid hash key." },
            {"CARD_PROGRAM_MISMATCH","Card program mismatch." },
            {"FOREIGN_CARD_IS_NOT_ALLOWED_FOR_THIS_MERCHANT","Foreign card is not allowed for this merchant." },
            {"FOREIGN_CARD_IS_NOT_ALLOWED_FOR_THIS_POS","Foreign card is not allowed for this pos." },
            {"FOREIGN_CARD_COMMISSION_IS_NOT_SET_FOR_THIS_MERCHANT","Foreign card commission is not set for this merchant." },
            {"FOREIGN_CARD_IS_NOT_SET_FOR_THIS_MERCHANT_POS_COMMISSION","Foreign card is not set for this merchant pos commission." },
            {"MERCHANT_IS_NOT_ALLOWED_TO_PAY_WITH_CARD_TOKEN","Merchant is not allowed to pay with card token." },
            {"THE_PAYMENT_IS_NOT_WITH_MARKETPLACE_API","The payment is not with marketplace api." },
            {"HASH_KEY_MICHMATCH","Hash key mismatch" },
            {"MERCHANT_IS_NOT_ALLOWED_FOR_PAY_BY_TOKEN","Merchant is not allowed for pay by token." },
            {"PAYBYTOKEN_COMMISSION_WAS_NOT_SETUP","PayByToken commission was not setup." },
            {"CARD_NUMBER_LENGTH_MUST_BE_15_TO_16","Card  number length  must  be 15 to 16" },
            { "","Total length of card number and  cvv must  be 19" }
        };

        public const int PAYMENT_PENDING = 69;
        public const int API_SERVICE_SUCCESS_CODE = 100;
        public const int API_SERVICE_FAILED_CODE = 422;
        public const int API_SERVICE_UNAUTHENTICATED = 401;
        public const int API_SERVICE_DEFAULT_VALIDATION_ERROR = 1001;
        public const int API_SERVICE_IP_VALIDATION_ERROR = 1002;
        public const int API_SERVICE_HASHKEY_VALIDATION_ERROR = 1003;
        public const int API_SERVICE_CURRENCY_NOT_SUPPORTED = 1004;
        public const int API_SERVICE_ITEM_TOTAL_MISMATCH = 1005;
        public const int API_SERVICE_NAME_MISMATCH_WITH_HASH_KEY = 1006;
        public const int API_SERVICE_SURNAME_MISMATCH_WITH_HASH_KEY = 1007;
        public const int API_SERVICE_BIRTH_YEAR_MISMATCH_WITH_HASH_KEY = 1008;
        public const int API_SERVICE_IP_ADDRESS_MISMATCH_WITH_HASH_KEY = 1009;
        public const int API_SERVICE_HASH_KEY_MISMATCH = 1010;
        public const int API_SERVICE_KYC_INVALID_USER = 1011;
        public const int API_SERVICE_INVALID_CHARACTER_IN_REQUEST = 1012;
        public const int API_SERVICE_DUPLICATE_REQUEST_ERROR = 1013;
        public const int API_SERVICE_JWT_VERIFICATION_ERROR = 1014;
        public const int API_SERVICE_ITEMS_CAN_NOT_BE_EMPTY = 1015;
        public const int API_SERVICE_OXIVO_AUTH_FAILED = 1015; // OXIVO AUTH FAILED
        public const int API_SERVICE_OXIVO_API_ERROR = 1016; // OXIVO AUTH FAILED
        public const int API_SERVICE_PAVO_AUTH_FAILED = 1017; // PAVO AUTH FAILED
        public const int API_SERVICE_PAVO_API_ERROR = 1018; // PAVO AUTH FAILED
        public const int API_SERVICE_NOT_PAVO_MERCHANT = 1019; // MERCHANT TYPE IS NOT PAVO
        public const int API_SERVICE_NOT_OXIVO_MERCHANT = 1020; // MERCHANT TYPE IS NOT OXIVO
        public const int API_SERVICE_ALREADY_CREATED = 1021; // ALREADY CREATED
        public const int API_SERVICE_NO_DATA_FOUND = 1022; // No data found
        public const int API_SERVICE_PAVO_UNCOUNTED_TRANSACTION = 1023; // PAVO UNCOUNTED
        public const int API_SERVICE_PAVO_TRANSACTION_REFUND_FAILED = 1024; // PAVO Refund Failed
        public const int API_SERVICE_OXIVO_UNCOUNTED_TRANSACTION = 1025; // OXIVO UNCOUNTED
        public const int API_SERVICE_FP_MT_FILE_ALREADY_EXISTS = 1026; // FP MT FILE ALREADY EXISTS
        public const int API_SERVICE_NOT_FP_MT_MERCHANT = 1027; // MERCHANT TYPE IS NOT FP_MT
        public const int API_SERVICE_FP_MT_FILE_ALREADY_PROCESSED = 1028; // FP MT FILE ALREADY PROCESSED
        public const int API_SERVICE_FP_MT_FILE_NOT_EXISTS = 1029; // FP MT FILE NOT EXISTS
        public const int API_SERVICE_GOOGLE_RECAPTCHA_VALIDATION_FAILED = 1030; // google  recaptcha validation failed
        public const int API_SERVICE_FP_MT_TRANSACTION_REFUND_FAILED = 1031; // FP MT Refund Failed
        public const int API_SERVICE_IMPORTED_TRANSACTION_NOT_FOUND = 1032; // Imported Transaction Not Found
        public const int API_SERVICE_WITHDRAWAL_FILE_ALREADY_EXISTS = 1033; // WITHDRAWAL FILE ALREADY EXISTS
        public const int API_SERVICE_WITHDRAWAL_FILE_ALREADY_PROCESSED = 1034; // WITHDRAWAL FILE ALREADY PROCESSED
        public const int API_SERVICE_PHYSICAL_POS_SETTINGS_NOT_FOUND = 1035;
        public const int API_SERVICE_USER_NOT_FOUND = 2001;
        public const int API_SERVICE_MERCHANT_NOT_FOUND = 2002;
        public const int API_SERVICE_SUB_MERCHANT_NOT_FOUND = 2003;
        public const int API_SERVICE_RECEIVER_NOT_FOUND = 2004;
        public const int API_SERVICE_WALLET_NOT_FOUND = 2005;
        public const int API_SERVICE_CURRENCY_NOT_FOUND = 2006;
        public const int API_SERVICE_CURRENCY_SETTING_NOT_SET = 2007;
        public const int API_SERVICE_WALLET_SERVICE_DISABLE= 2008;
        public const int API_SERVICE_WALLET_ALREADY_EXISTS = 2009;
        public const int API_SERVICE_WALLET_AMOUNT_DELETE_REFUSE = 2010;
        public const int API_SERVICE_INSUFFICIENT_BALANCE = 2011;
        public const int API_SERVICE_WALLET_NOT_UPDATED = 2012;
        public const int API_SERVICE_RECEIVER_WALLET_NOT_FOUND = 2013;
        public const int API_SERVICE_PHONE_NUMBER_ALREADY_EXIST = 2014;
        public const int API_SERVICE_EMAIL_ALREADY_EXIST = 2015;
        public const int API_SERVICE_SUB_MERCHANT_ALREADY_EXIST = 2016;
        public const int API_SERVICE_SUB_MERCHANT_CANT_BE_DELETED = 2017;
        public const int API_SERVICE_MERCHANT_KEY_IDENTIFICATION_ERROR = 2018;
        public const int API_SERVICE_USER_WITH_EMAIL_ALREADY_EXIST = 2019;
        public const int API_SERVICE_USER_WITH_PHONE_ALREADY_EXIST = 2020;
        public const int API_SERVICE_USER_WITH_TERMINAL_NO_ALREADY_EXIST = 2021;
        public const int API_SERVICE_SUB_MERCHANT_ID_FORAMT = 2022;
        public const int API_SERVICE_WALLET_NOT_FOUND_FOR_THIS_CURRENCY = 2023;
        public const int API_SERVICE_POS_NOT_SET = 2024;
        public const int API_SERVICE_MERCHANT_AUTHORIZATION_ERROR = 2025;
        public const int API_SERVICE_TRANSACTION_NOT_FOUND = 2026;
        public const int API_SERVICE_MERCHANT_TERMINAL_NOT_FOUND = 2027;
        public const int API_SERVICE_MERCHANT_APPLICATION_NOT_ASSIGNED = 2028;
        public const int API_SERVICE_MERCHANT_APPLICATION_REQUEST_PENDING = 2029;
        public const int API_SERVICE_MERCHANT_APPLICATION_IS_NOT_PENDING = 2030;
        public const int API_SERVICE_MERCHANT_APPLICATION_ALREADY_ASSIGNED = 2031;
        public const int API_SERVICE_MERCHANT_APPLICATION_NOT_FOUND = 2032;
        public const int API_SERVICE_MERCHANT_APPLICATION_ASSIGN_IS_NOT_PENDING = 2033;
        public const int API_SERVICE_MERCHANT_APPLICATION_USER_FAIL_ATTEMPTS_REACHED = 2034;
        public const int API_SERVICE_STATISTICAL_DATA_NOT_FOUND = 2035;
        public const int API_SERVICE_BRAND_NOT_ALLOWED = 2036;
        public const int API_USER_BLOCKED = 2037;
        public const int API_SERVICE_MERCHANT_IS_INACTIVE = 2038;
        public const int API_SERVICE_MERCHANT_IS_BLOCKED = 2039;
        public const int API_SERVICE_SETTLEMENT_NOT_FOUND = 2040;
        public const int API_ALREADY_HAS_PENDING_PROCESS = 2041;
        public const int API_SERVICE_MERCHANT_DUPLICATE_IMPORTED_TRANSACTION_FOUND = 2042;

        ///'SALE' :"PREFIX [E-30]','http_code" = 200
        public const int API_SERVICE_SALE_NOT_FOUND = 3001;

        public const int API_SERVICE_MERCHANT_POS_COMMISSION_NOT_FOUND = 3002;
        public const int API_SERVICE_POS_NOT_FOUND = 3003;
        public const int API_SERVICE_SALE_BANK_NOT_FOUND = 3004;
        public const int API_SERVICE_SALE_INVOICE_ID_ALREADY_PROCESSED = 3005;
        public const int API_SERVICE_SALE_INVOICE_ID_IN_PROGRESS_STATE = 3006;
        public const int API_SERVICE_TEMPORARY_PAYMENT_RECORD_MANAGEMENT_FAIL = 3007;
        public const int API_SERVICE_PAYMENT_FAILED = 3008;
        public const int API_SERVICE_FASTPAY_WALLET_SERVICE_AUTH_TOKEN_NOT_FOUND = 3009;
        public const int API_SERVICE_CARD_FROM_THE_CARD_TOKEN_PROVIDER_NOT_FOUND = 3010;
        public const int API_SERVICE_MERCHANT_COMMISSION_IS_NOT_SET = 3011;
        public const int API_SERVICE_MERCHANT_OXIVO_COMMISSION_IS_NOT_ENABLED = 3012;
        public const int API_SERVICE_CACHE_DATA_NOT_FOUND_WITH_KEY_REFERENCE = 3013;
        public const int API_SERVICE_INVALID_QR_REFERENCE_CODE = 3014;
        public const int API_SERVICE_FASTPAY_WALLET_SERVICE_ERROR_RESPONSE = 3015;
        public const int API_SERVICE_FASTPAY_WALLET_SERVICE_UNDEFINED_PAYMENT_SECURITY_TYPE = 3016;
        public const int API_SERVICE_3D_SECURE_PAYMENT_FORM_NOT_FOUND = 3017;
        public const int API_SERVICE_SALE_SECURE_FORM_SUBMISSION_INVALID_URL_FORMAT = 3018;
        public const int API_SERVICE_CARD_TOKEN_PROVIDER_BANK_NOT_FOUND = 3019;
        public const int API_SERVICE_PAYMENT_GATEWAY_ERROR = 3020;
        public const int API_SERVICE_DUPLICATE_OXIVO_TRANSACTION_ERROR = 3021;
        public const int API_SERVICE_SALE_COMMISSION_NOT_SET = 3022;
        public const int API_SERVICE_SALE_COMMISSION_IS_GREATER_THAN_TOTAL_AMOUNT = 3023;
        public const int API_SERVICE_SALE_TRANSACTION_CAUGHT_FOR_FRAUD = 3024;
        public const int API_SERVICE_SALE_INVALID_TRANSACTION_STATE = 3025;
        public const int API_SERVICE_SALE_EMPTY_FASTPAY_WALLET_TRANSACTION_ID = 3026;
        public const int API_SERVICE_SALE_EMPTY_FASTPAY_WALLET_TRANSACTION_ENTITY = 3027;
        public const int API_SERVICE_CARD_TOKEN_NOT_FOUND = 3028;
        public const int API_SERVICE_SALE_NET_AMOUNT_LESS_OR_EQUAL_TO_ZERO = 3029;
        public const int API_SERVICE_DUPLICATE_PAVO_TRANSACTION_ERROR = 3030;
        public const int API_SERVICE_DUPLICATE_FP_MT_TRANSACTION_ERROR = 3031;
        public const int API_SERVICE_DUPLICATE_FP_MT_REFUND_PHYSIAL_POS_ERROR = 3032;
        public const int API_SERVICE_DUPLICATE_FP_MT_NOT_ACCEPTING_TRANSACTION = 3033;
        public const int API_SERVICE_DUPLICATE_IMPORTED_WITHDRAWAL_ERROR = 3034;
        public const int API_SERVICE_IMPORTED_WITHDRAWAL_GOT_EXCEPTION = 3035;
        public const int API_SERVICE_IMPORTED_WITHDRAWAL_BANK_NOT_FOUND = 3036;
        public const int API_SERVICE_IMPORTED_WITHDRAWAL_STATE_NOT_ACCEPTABLE = 3037;
        public const int API_SALE_TIMED_OUT_RESPONSE = 3038;
        public const int API_SERVICE_IMPORTED_TRANSACTION_GOT_EXCEPTION = 3039;
        public const int API_SERVICE_NON_REFUNDABLE_TRANSACTION_STATE = 4001;
        public const int API_SERVICE_REFUND_REQUEST_AMOUNT_EXCEEDS_THE_INVOICE_TOTAL = 4002;
        public const int API_SERVICE_REFUND_GRACE_PERIOD_INPUT_AMOUNT_ERROR = 4003;
        public const int API_SERVICE_REFUND_WALLET_INSUFFICIENT_BALANCE = 4004;
        public const int API_SERVICE_DUPLICATE_REFUND_REFERENCE_ID = 4005;
        public const int API_SERVICE_REFUND_PAYMENT_TYPE_IS_NOT_IN_PAYMENT_RECEIVE_OPTIONS = 4006;
        public const int API_SERVICE_REFUND_PURCHASE_ID_IS_ABSENT_FOR_REFUND_TO_BRAND_WALLET = 4007;
        public const int API_SERVICE_REFUND_FAILED = 4008;
        public const int API_SERVICE_REFUND_AWAITING = 4009;
        public const int API_SERVICE_REFUND_FAILED_SALE_HAVE_NOT_BEEN_PROCESSED = 4010;
        public const int API_SERVICE_REFUND_REMAIN_AMOUNT_INVALID = 4011;
        public const int API_SERVICE_MERCHANT_B2C_COMMISSION_NOT_SET = 5001;
        public const int API_SERVICE_CANNOT_SEND_MONEY_YOURSELF = 5002;
        public const int API_SERVICE_TRANSACTION_DATA_INSERT_FAILED = 5003;
        public const int API_SERVICE_AMOUNT_SHOULD_BE_GREATER = 5004;
        public const int API_SERVICE_AMOUNT_CANNOT_BE_LESS = 5005;
        public const int API_SERVICE_PERMISSION_AND_AMOUNT_CANNOT_BE_LESS = 5006;
        public const int API_SERVICE_BANK_NOT_FOUND = 5007;
        public const int API_SERVICE_COMMISON_FEE_IS_GREATER_THAN_SEND_MONEY = 5004;
        public const int API_SERVICE_USER_SEND_MONEY_LIMIT_EXCEED = 5005;
        public const int API_SERVICE_SEND_MONEY_SUCCESS_CREATE_ACCOUNT_WITHIN_24_HOURS = 5008;
        public const int API_SERVICE_SEND_MONEY_SUCCESS_CREATE_ACCOUNT_WITHIN_72_HOURS = 5009;
        public const int API_SERVICE_B2C_REQUEST_CREATED_CASHOUT_SERVER_EXCEPTION = 5010;
        public const int API_SERVICE_COMMISSION_FEE_IS_GREATER_THAN_SEND_MONEY = 5011;
        public const int API_SERVICE_RECEIVER_ACCEPT_MONEY_LIMIT_EXCEED = 5012;
        public const int API_SERVICE_USER_MAX_SEND_MONEY_LIMIT_EXCEED = 5013;
        public const int API_SERVICE_CASHOUT_DATA_INSERTION_FAILED = 5014;
        public const int API_SERVICE_RECIPENT_ACCOUNT_BAN_FROM_THE_SYSTEM = 5015;
        public const int API_SERVICE_RECIPENT_ACCOUNT_UNDER_REVIEW = 5016;
        public const int API_SERVICE_USER_MAX_RECEIVE_MONEY_LIMIT_EXCEED = 5017;
        public const int API_SERVICE_MERCHANT_COMMISSION_NOT_SET_FOR_WALLET_PAYMENT = 5018;
        public const int API_SERVICE_TRANSACTION_WILL_BE_CREATED_AFTER_PRELIMINARY_REVIEW = 5019;
        public const int API_SERVICE_DEPOSIT_NOT_FOUND = 6001;
        public const int API_SERVICE_DEPOSIT_REQUEST_UNDER_REVIEW = 6010;
        public const int API_SERVICE_DEPOSIT_CREATION_FAILED = 6011;
        public const int API_SERVICE_DEPOSIT_AMOUNT_CAN_NOT_EMPTY = 6012;
        public const int API_SERVICE_DEPOSIT_PENDING_DEPOSITS = 6013;
        public const int API_SERVICE_DEPOSIT_CURRENCY_NOT_SET = 6014;
        public const int API_SERVICE_DEPOSIT_CAN_NOT_UPDATE = 6015;
        public const int API_SERVICE_DEPOSIT_AMOUNT_LIMIT_EXCEED = 6016;
        public const int API_SERVICE_DEPOSIT_CAN_NOT_DELETE = 6017;
        public const int API_SERVICE_DEPOSIT_DELETION_FAILED = 6050;
        public const int API_SERVICE_WITHDRAWAL_COMMISSION_NOT_SET = 7001;
        public const int API_SERVICE_LESS_THAN_MIN_WITHDRAWAL_AMOUNT = 7002;
        public const int API_SERVICE_WITHDRAWAL_REQUEST_UNDER_REVIEW = 7003;
        public const int API_SERVICE_WITHDRAWAL_REQUESTED_CASHOUT_SERVER_EXP = 7004;
        public const int API_SERVICE_MAX_WITHDRAWAL_LIMIT_EXCEED = 7005;
        public const int API_SERVICE_WITHDRAWAL_NOT_PERSONAL_BANK_ACC = 7006;
        public const int API_SERVICE_WITHDRAWAL_NO_BANK_FOR_IBAN = 7007;
        public const int API_SERVICE_WITHDRAWAL_NO_BANK_FOR_ACCOUNT = 7008;
        public const int API_SERVICE_UNKNOWN_ERROR = 9000;
        public const int API_SERVICE_DATABASE_ERROR = 9001;
        public const int API_SERVICE_DATABASE_ERROR_FROM_REFUND_REQUEST = 9002;
        public const int API_SERVICE_UNEXPECTED_RESPONSE_ERROR = 9003;
        public const int API_SERVICE_OXIVO_TRANSACTION_FAILED_TO_SAVE = 9004;
        public const int API_SERVICE_SALE_DATABASE_ERROR = 9005;
        public const int API_SERVICE_ACTIVE_AML_DETECTED = 9010;
        public const int API_SERVICE_ACTIVE_AND_APPROVE_AML_DETECTED = 9011;
        public const int API_SERVICE_FTP_CONNECTION_FAILED = 8000;
        public const int API_SERVICE_FAILED_TO_UPLOAD_BTRANS_REPORT = 8001;

        public static readonly Dictionary<int, string> API_SERVICE_STATUS_MESSAGE = new Dictionary<int, string>(){
            { API_SERVICE_SUCCESS_CODE, "Successful" },
            { API_SERVICE_FAILED_CODE, "Failed" },
            { API_SERVICE_NO_DATA_FOUND, "No data found" },
            { API_SERVICE_UNKNOWN_ERROR ,  "Unknown error" },
            //'REQUEST': PREFIX [E-10],"http_code" = 400
            { API_SERVICE_IP_VALIDATION_ERROR,  "This ip is not allowed" },
            { API_SERVICE_HASHKEY_VALIDATION_ERROR,  "Invalid Request" },
            { API_SERVICE_DEFAULT_VALIDATION_ERROR ,  "Validation Error" },
            { API_SERVICE_CURRENCY_NOT_SUPPORTED ,   "" },

            //'IDENTIFICATION': PREFIX [E-20],"http_code" = 200

            { API_SERVICE_USER_NOT_FOUND ,   "User not found" },
            { API_SERVICE_MERCHANT_NOT_FOUND ,   "Merchant not found" },
            { API_SERVICE_WALLET_NOT_FOUND ,   "Wallet not found" },
            { API_SERVICE_WALLET_NOT_FOUND_FOR_THIS_CURRENCY ,   "Wallet not found for this currency" },
            { API_SERVICE_CURRENCY_NOT_FOUND ,   "Currency not found" },
            { API_SERVICE_CURRENCY_SETTING_NOT_SET ,   "Currency setting is not set" },
            { API_SERVICE_WALLET_SERVICE_DISABLE ,  "Wallet unitOfWork is disable. Please contact with support." },
            { API_SERVICE_INSUFFICIENT_BALANCE , "Insufficient balance" },
            { API_SERVICE_SUB_MERCHANT_NOT_FOUND ,   "Submerchant not found" },
            { API_SERVICE_RECEIVER_NOT_FOUND ,   "Receiver not found" },
            { API_SERVICE_WALLET_ALREADY_EXISTS ,   "" },
            { API_SERVICE_WALLET_AMOUNT_DELETE_REFUSE , "Wallet Not Empty." },
            { API_SERVICE_WALLET_NOT_UPDATED ,   "Wallet not updated" },
            { API_SERVICE_POS_NOT_SET ,   "You can't complete this process for this currency" },
            { API_SERVICE_POS_NOT_FOUND ,   "POS not found" },

            { API_SERVICE_NAME_MISMATCH_WITH_HASH_KEY ,  "Name mismatch with hash_key" },
            { API_SERVICE_SURNAME_MISMATCH_WITH_HASH_KEY ,  "Surname mismatch with hash_key" },
            { API_SERVICE_BIRTH_YEAR_MISMATCH_WITH_HASH_KEY ,  "Birth year mismatch with hash_key" },
            { API_SERVICE_IP_ADDRESS_MISMATCH_WITH_HASH_KEY ,  "IP address mismatch with hash_key" },
            { API_SERVICE_HASH_KEY_MISMATCH ,  "Hash key mismatch" },
            { API_SERVICE_KYC_INVALID_USER ,  "KYC verification failed" },
            { API_SERVICE_MERCHANT_KEY_IDENTIFICATION_ERROR ,  "Not A Valid Merchant Key" },
            { API_SERVICE_USER_WITH_EMAIL_ALREADY_EXIST , "User With Email Already Exists" },
            { API_SERVICE_USER_WITH_PHONE_ALREADY_EXIST , "User With Phone Already Exists" },
            { API_SERVICE_USER_WITH_TERMINAL_NO_ALREADY_EXIST  , "User With Terminal Number Already Exists" },

            //refund

            { API_SERVICE_NON_REFUNDABLE_TRANSACTION_STATE , "Non refundable transaction state." },
            { API_SERVICE_REFUND_REQUEST_AMOUNT_EXCEEDS_THE_INVOICE_TOTAL , "Input amount exceeds total transaction amount" },
            { API_SERVICE_REFUND_GRACE_PERIOD_INPUT_AMOUNT_ERROR , "Try Refund again after '.BankRefund::REFUND_GRACE_PERIOD.' seconds" },
            { API_SERVICE_REFUND_WALLET_INSUFFICIENT_BALANCE , "Insufficient balance for refund" },
            { API_SERVICE_DUPLICATE_REFUND_REFERENCE_ID , "Duplicate refund reference id." },
            { API_SERVICE_REFUND_PAYMENT_TYPE_IS_NOT_IN_PAYMENT_RECEIVE_OPTIONS , "Payment type is not in payment received optionss for refund" },
            { API_SERVICE_REFUND_PURCHASE_ID_IS_ABSENT_FOR_REFUND_TO_BRAND_WALLET , "Purchase id is absent for refund to brand wallet." },

            
            //'MONEY TRANSFER' : PREFIX [E-50],"http_code" = 200
            { API_SERVICE_MERCHANT_B2C_COMMISSION_NOT_SET ,   "Commissions are not set yet. please contact support if this error persists !" },
            { API_SERVICE_CANNOT_SEND_MONEY_YOURSELF ,   "You cannot send money to yourself" },
            { API_SERVICE_TRANSACTION_DATA_INSERT_FAILED ,   "Transaction data insertion failed" },
            { API_SERVICE_AMOUNT_SHOULD_BE_GREATER ,   "Amount should not be greater than <var1>" },
            { API_SERVICE_AMOUNT_CANNOT_BE_LESS ,  "Amount can't be less than <var1>" },
            { API_SERVICE_PERMISSION_AND_AMOUNT_CANNOT_BE_LESS ,   "You don't have permission . Amount can't be less than <var1>" },
            { API_SERVICE_BANK_NOT_FOUND ,  "Bank not found" },
            { API_SERVICE_SEND_MONEY_SUCCESS_CREATE_ACCOUNT_WITHIN_24_HOURS ,  "Your request to send money has been successfully received. Since the user is not verified, the money will be transferred to the <var1> wallet when he/she update Kyc information within 24 hours. If no action is taken, the money will be returned to your account after 24 hours." },
            { API_SERVICE_SEND_MONEY_SUCCESS_CREATE_ACCOUNT_WITHIN_72_HOURS ,  "Your request to send money has been successfully received. Since the user is not in the system, the money will be transferred to the <var1> wallet when he/she registers within 72 hours. If no action is taken, the money will be returned to your account after 72 hours." },
            { API_SERVICE_B2C_REQUEST_CREATED_CASHOUT_SERVER_EXCEPTION ,  "B2C request created but cashout server got exception" },
            { API_SERVICE_COMMISSION_FEE_IS_GREATER_THAN_SEND_MONEY ,  "You can't send money because commission fee is greater than send amount" },
            { API_SERVICE_RECEIVER_ACCEPT_MONEY_LIMIT_EXCEED ,  "Receiver can't receive that amount beacuse his amount limit will exceed" },
            { API_SERVICE_USER_MAX_SEND_MONEY_LIMIT_EXCEED ,  "User max send money limit exceed" },
            { API_SERVICE_CASHOUT_DATA_INSERTION_FAILED ,  "Cashout data Insertion failed" },
            { API_SERVICE_RECIPENT_ACCOUNT_BAN_FROM_THE_SYSTEM ,  "This transaction cannot be performed due to the recipient account's ban from the system." },
            { API_SERVICE_RECIPENT_ACCOUNT_UNDER_REVIEW ,  "Your transaction cannot be performed at the moment because the recipient account is under review. Please try again later." },
            { API_SERVICE_USER_MAX_RECEIVE_MONEY_LIMIT_EXCEED ,  "User max receive money limit exceed" },
            { API_SERVICE_MERCHANT_COMMISSION_NOT_SET_FOR_WALLET_PAYMENT ,  "Merchant Commissions are not set yet for wallet payment. please contact support if this error persists !" },
            { API_SERVICE_TRANSACTION_WILL_BE_CREATED_AFTER_PRELIMINARY_REVIEW ,  "Your transaction will be completed after a preliminary review" },
            { API_SERVICE_ACTIVE_AML_DETECTED ,  "AML transaction is detected" },
            { API_SERVICE_ACTIVE_AND_APPROVE_AML_DETECTED ,  "AML transaction is detected" },

            //Transaction
            { API_SERVICE_TRANSACTION_NOT_FOUND ,  "Transaction not found" },

            //Deposit
            { API_SERVICE_DEPOSIT_NOT_FOUND ,  "Deposit not found" },
            { API_SERVICE_DEPOSIT_REQUEST_UNDER_REVIEW ,  "Your deposit request is under review" },
            { API_SERVICE_DEPOSIT_CREATION_FAILED ,  "Deposit creation failed" },
            { API_SERVICE_DEPOSIT_AMOUNT_CAN_NOT_EMPTY ,  "Deposit amount can't be empty" },
            { API_SERVICE_DEPOSIT_PENDING_DEPOSITS ,  "You have pending deposits, you can't create now" },
            { API_SERVICE_DEPOSIT_CURRENCY_NOT_SET ,  "Currency settings not set yet. please contact support if this error persists" },
            { API_SERVICE_DEPOSIT_CAN_NOT_UPDATE ,  "You can't update this deposit" },
            { API_SERVICE_DEPOSIT_AMOUNT_LIMIT_EXCEED ,  "You can't deposit that amount because your amount limit will exceed" },
            { API_SERVICE_DEPOSIT_CAN_NOT_DELETE ,  "Deposit can't be deleted" },
            { API_SERVICE_DEPOSIT_DELETION_FAILED ,  "Deposit deletion failed" },

            //'WITHDRAWAL' : PREFIX [E-30],"http_code" = 200
            { API_SERVICE_WITHDRAWAL_NO_BANK_FOR_IBAN ,  "Bank not found for this iban" },
            { API_SERVICE_WITHDRAWAL_NO_BANK_FOR_ACCOUNT ,  "Bank not found of this account" },
            { API_SERVICE_WITHDRAWAL_COMMISSION_NOT_SET ,  "Withdrawal commission is not set" },
            { API_SERVICE_LESS_THAN_MIN_WITHDRAWAL_AMOUNT ,  "Minimum withdrawal amount is <varX>" },
            { API_SERVICE_WITHDRAWAL_REQUEST_UNDER_REVIEW ,  "Your withdrawal request is under review" },
            { API_SERVICE_WITHDRAWAL_REQUESTED_CASHOUT_SERVER_EXP ,  "Withdrawal request created but cashout server got exception" },
            { API_SERVICE_MAX_WITHDRAWAL_LIMIT_EXCEED ,  "User max withdrawal limit exceed" },
            { API_SERVICE_WITHDRAWAL_NOT_PERSONAL_BANK_ACC ,  "You can only create a withdrawal request to your personal bank account" },
            { API_SERVICE_SUB_MERCHANT_ID_FORAMT ,  "Invalid Sub Merchant ID" },

            { API_SERVICE_GOOGLE_RECAPTCHA_VALIDATION_FAILED ,  "Sorry! Google recaptcha detected you as a bot." },
            { API_SALE_TIMED_OUT_RESPONSE ,  "Timed out response" },
        };

        public const string WALLET_SERVICE_TOPUP ="walletservice.topup";
        public const string WALLET_SERVICE_SENDMONEY ="walletservice.sendmoney";
        public const string WALLET_SERVICE_SENDMONEY_LIST ="walletservice.moneytransfer.sendmoneylist";
        public const string WALLET_SERVICE_ADD_WALLET ="walletservice.add.wallet";
        public const string WALLET_SERVICE_DELETE_WALLET ="walletservice.delete.wallet";
        public const string WALLET_SERVICE_LIST_WALLET ="walletservice.list.wallets";
        public const string ROUTE_SUB_MERCHANT_ADD ="submerchant.add";
        public const string ROUTE_SUB_MERCHANT_DELETE ="submerchant.delete";
        public const string ROUTE_SUB_MERCHANT_EDIT ="submerchant.edit";
        public const string ROUTE_SUB_MERCHANT_LIST ="submerchant.list";

        public static readonly string[] SUBMERCHANT_ROUTES = new string[]{
            ROUTE_SUB_MERCHANT_ADD, ROUTE_SUB_MERCHANT_EDIT, ROUTE_SUB_MERCHANT_LIST, ROUTE_SUB_MERCHANT_DELETE
        };

        public const string WALLET_SERVICE_DEPOSIT_CREATE ="walletservice.deposit.create";
        public const string WALLET_SERVICE_DEPOSIT_UPDATE ="walletservice.deposit.update";
        public const string WALLET_SERVICE_DEPOSIT_DELETE ="walletservice.deposit.delete";
        public const string WALLET_SERVICE_DEPOSIT_LIST ="walletservice.deposit.list";
        public const string WALLET_SERVICE_DEPOSIT_DETAILS ="walletservice.deposit.details";
        public const string WALLET_SERVICE_DEPOSIT_CREATE_FORM ="walletservice.deposit.createForm";
        public const string WALLET_SERVICE_TRANSACTION_LIST ="walletservice.transactionList";
        public const string WALLET_SERVICE_TRANSACTION_DETAILS ="walletservice.transactionDetails";
        public const string WALLET_SERVICE_WITHDRAWL_ADD ="walletservice.withdrawal.add";
        public const string WALLET_SERVICE_WITHDRAWL_LIST ="walletservice.withdrawal.list";
        public const string WALLET_SERVICE_WITHDRAWL_DETAIL ="walletservice.withdrawal.detail";
        public const string WALLET_SERVICE_KYC_VERIFICATION ="walletservice.kycverification";
    }
}
