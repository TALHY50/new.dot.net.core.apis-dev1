namespace SharedLibrary.Models;
using Newtonsoft.Json;

public partial class Merchant
{
    [JsonProperty("id")]
    public uint Id { get; set; }

    [JsonProperty("user_id")]
    public int UserId { get; set; }

    [JsonProperty("merchant_key")]
    public string MerchantKey { get; set; } = null!;

    [JsonProperty("site_url")]
    public string? SiteUrl { get; set; }

    [JsonProperty("success_link")]
    public string? SuccessLink { get; set; }

    [JsonProperty("fail_link")]
    public string? FailLink { get; set; }

    [JsonProperty("logo")]
    public string? Logo { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("description")]
    public string? Description { get; set; }

    [JsonProperty("dpl_firsttime_limt")]
    public double? DplFirsttimeLimt { get; set; }

    [JsonProperty("business_area")]
    public string? BusinessArea { get; set; }

    [JsonProperty("contact_person_name")]
    public string? ContactPersonName { get; set; }

    [JsonProperty("contact_person_phone")]
    public string? ContactPersonPhone { get; set; }

    [JsonProperty("contact_person_email")]
    public string? ContactPersonEmail { get; set; }

    [JsonProperty("merchant_type")]
    public int? MerchantType { get; set; }

    [JsonProperty("json_data")]
    public string? JsonData { get; set; }

    [JsonProperty("dpl_billing_fields")]
    public string? DplBillingFields { get; set; }

    [JsonProperty("first_transaction_date")]
    public DateTime? FirstTransactionDate { get; set; }

    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [JsonProperty("currency_id")]
    public int? CurrencyId { get; set; }

    [JsonProperty("full_company_name")]
    public string? FullCompanyName { get; set; }

    [JsonProperty("average_turnover")]
    public string? AverageTurnover { get; set; }

    [JsonProperty("authorized_person_name")]
    public string? AuthorizedPersonName { get; set; }

    [JsonProperty("authorized_person_phone_number")]
    public string? AuthorizedPersonPhoneNumber { get; set; }

    [JsonProperty("authorized_person_email")]
    public string? AuthorizedPersonEmail { get; set; }

    [JsonProperty("application_date")]
    public DateTime? ApplicationDate { get; set; }

    [JsonProperty("activation_date")]
    public DateTime? ActivationDate { get; set; }

    /// <summary>
    /// for wet signed document approval date
    /// </summary>

    [JsonProperty("wet_signed_document_approval_date")]
    public DateTime? WetSignedDocumentApprovalDate { get; set; }

    [JsonProperty("address1")]
    public string? Address1 { get; set; }

    [JsonProperty("address2")]
    public string? Address2 { get; set; }

    [JsonProperty("zip_code")]
    public string? ZipCode { get; set; }

    [JsonProperty("latitude")]
    public decimal? Latitude { get; set; }

    [JsonProperty("longitude")]
    public decimal? Longitude { get; set; }

    [JsonProperty("city")]
    public string? City { get; set; }

    [JsonProperty("country_id")]
    public int? CountryId { get; set; }

    [JsonProperty("iso_country_code")]
    public string? IsoCountryCode { get; set; }

    [JsonProperty("mcc")]
    public string? Mcc { get; set; }

    [JsonProperty("tckn")]
    public string? Tckn { get; set; }

    [JsonProperty("vkn")]
    public string? Vkn { get; set; }

    [JsonProperty("tax_no")]
    public string? TaxNo { get; set; }

    [JsonProperty("tax_office")]
    public string? TaxOffice { get; set; }

    [JsonProperty("expected_volume")]
    public string? ExpectedVolume { get; set; }

    [JsonProperty("remote_sub_merchant_id")]
    public string? RemoteSubMerchantId { get; set; }

    [JsonProperty("rolling_status")]
    public sbyte? RollingStatus { get; set; }
    /// <summary>
    /// It is % value
    /// </summary>

    [JsonProperty("rolling_reserve_amount")]
    public double? RollingReserveAmount { get; set; }

    [JsonProperty("rolling_reserve_time_limit")]
    public sbyte? RollingReserveTimeLimit { get; set; }
    /// <summary>
    /// 1=&gt; hours, 2 =&gt; days, 3 =&gt;months, 4 =&gt; years
    /// </summary>

    [JsonProperty("settlement_type")]
    public sbyte SettlementType { get; set; }

    [JsonProperty("merchant_secret")]
    public string? MerchantSecret { get; set; }

    [JsonProperty("test_merchant_key")]
    public string? TestMerchantKey { get; set; }

    [JsonProperty("test_merchant_secret")]
    public string? TestMerchantSecret { get; set; }
    /// <summary>
    /// 0=&gt;inactive;1=&gt;active
    /// </summary>

    [JsonProperty("status")]
    public sbyte Status { get; set; }
    /// <summary>
    /// 0=&gt;awaiting approval, 1=&gt;approved, 2=&gt;rejected
    /// </summary>

    [JsonProperty("tenant_approval_status")]
    public bool? TenantApprovalStatus { get; set; }
    /// <summary>
    /// tenant reject reason
    /// </summary>

    [JsonProperty("reason")]
    public string? Reason { get; set; }
    /// <summary>
    /// 0=not blocked, 1=blocked
    /// </summary>

    [JsonProperty("is_block")]
    public sbyte IsBlock { get; set; }
    /// <summary>
    /// 0=&gt;not 3d user, 1=&gt;3d user
    /// </summary>

    [JsonProperty("is_3d")]
    public sbyte Is3d { get; set; }
    /// <summary>
    /// 0 = 2d, 1= 3D
    /// </summary>

    [JsonProperty("is_manual_pos_3d")]
    public sbyte IsManualPos3d { get; set; }

    /// <summary>
    /// 0 =&gt; White Label 2D Only 1 =&gt; White Label 2D/3D, Allow User to Choose 2 =&gt; White Label 3D Only 4 =&gt; 2D/3D Branded Solution 8 =&gt; Redirected White Label
    /// </summary>

    [JsonProperty("payment_integration_option")]
    public sbyte PaymentIntegrationOption { get; set; }
    /// <summary>
    /// 1=branded, 2=white Label
    /// </summary>

    [JsonProperty("dpl_option")]
    public sbyte? DplOption { get; set; }

    [JsonProperty("sale_platform")]
    public string? SalePlatform { get; set; }

    /*[JsonProperty("sipay_accountant_email")]
    public string? SipayAccountantEmail { get; set; }*/

    /// <summary>
    /// 0 = dont send, 1 = send
    /// </summary>

    [JsonProperty("send_pf_records")]
    public sbyte? SendPfRecords { get; set; }
    /// <summary>
    /// 0=&gt;disable,
    /// 1=&gt; Convert foreign currency to TRY Only when limit exceed,
    /// 2 =&gt; Convert foreign currency to TRY Directly
    /// </summary>

    [JsonProperty("allow_foreign_currency_to_tl")]
    public sbyte? AllowForeignCurrencyToTl { get; set; }

    [JsonProperty("total_transaction")]
    public sbyte? TotalTransaction { get; set; }

    /// <summary>
    /// 0=not allowed; 1=allowed
    /// </summary>

    [JsonProperty("is_allow_foreign_cards")]
    public sbyte? IsAllowForeignCards { get; set; }

    [JsonProperty("calculate_pos_by_bank")]
    public sbyte? CalculatePosByBank { get; set; }

    [JsonProperty("allow_pay_by_token")]
    public sbyte? AllowPayByToken { get; set; }

    /// <summary>
    /// 0=&gt;GENERAL_MERCHANT, 1=&gt;OWN_TEST_MERCHANT, 2=&gt;CRAFTGATE_MERCHANT, 3=&gt;DEPOSIT_BY_CREDIT_CARD_PF_MERCHANT, 4=&gt;TEST_PAYMENT_INTEGRATION_MERCHANT, 5=&gt;MARKETPLACE_MERCHANT, 6=&gt;OXIVO_MERCHANT, 7=&gt;WALLET_GATE_MERCHANT, 8=&gt;FASTPAY_WALLET_MERCHANT, 9=&gt;TAXI_MERCHANT, 10=&gt;PAVO_MERCHANT, 11=&gt;API_MERCHANT, 12=&gt;MT_MERCHANT, 13=&gt;BILL_PAYMENT_MERCHANT, 14=&gt;TENANT_MERCHANT
    /// </summary>

    [JsonProperty("type")]
    public sbyte? Type { get; set; }

    [JsonProperty("parent_merchant_id")]
    public int? ParentMerchantId { get; set; }

    [JsonProperty("linked_pf_merchant_id")]
    public int? LinkedPfMerchantId { get; set; }
    /// <summary>
    /// 0=not allowed, 1= allowed
    /// </summary>

    [JsonProperty("is_allow_b2c_automation")]
    public sbyte? IsAllowB2cAutomation { get; set; }

    [JsonProperty("is_receive_payment_receipt")]
    public sbyte? IsReceivePaymentReceipt { get; set; }

    [JsonProperty("payment_receipt_emails")]
    public string? PaymentReceiptEmails { get; set; }

    [JsonProperty("payment_receipt_emails_lang")]
    public string? PaymentReceiptEmailsLang { get; set; }

    /// <summary>
    /// 0=not allowed, 1= allowed
    /// </summary>

    [JsonProperty("is_allow_pay_bill")]
    public sbyte? IsAllowPayBill { get; set; }

    /// <summary>
    /// 0=not accepted, 1= accepted
    /// </summary>

    [JsonProperty("is_digital_contract_accept")]
    public sbyte? IsDigitalContractAccept { get; set; }
    /// <summary>
    /// 0 = old merchant, 1 = new merchant
    /// </summary>

    [JsonProperty("is_new_merchant")]
    public sbyte? IsNewMerchant { get; set; }

    [JsonProperty("is_allow_walletgate")]
    public sbyte? IsAllowWalletgate { get; set; }

    [JsonProperty("source_id")]
    public string? SourceId { get; set; }
    /// <summary>
    /// Iks district
    /// </summary>

    [JsonProperty("district")]
    public string? District { get; set; }
    /// <summary>
    /// area of district
    /// </summary>

    [JsonProperty("neighborhood")]
    public string? Neighborhood { get; set; }
    /// <summary>
    /// Iks license
    /// </summary>

    [JsonProperty("license_tag")]
    public string? LicenseTag { get; set; }
    /// <summary>
    /// 0=Regular Merchant, 1=Payment Facilitator Merchant
    /// </summary>

    [JsonProperty("psp_flag")]
    public sbyte PspFlag { get; set; }

    /// <summary>
    /// 0=Individual having no sub merchant,1=Main merchant having submerchants, 2=Submerchant
    /// </summary>

    [JsonProperty("main_seller_flag")]
    public sbyte MainSellerFlag { get; set; }
    /// <summary>
    /// 0=Unverified, 1=Verified
    /// </summary>

    [JsonProperty("is_iks_verified")]
    public sbyte IsIksVerified { get; set; }
    /// <summary>
    /// national address code
    /// </summary>

    [JsonProperty("national_address_code")]
    public string? NationalAddressCode { get; set; }

    /// <summary>
    /// merchant last transaction date
    /// </summary>

    [JsonProperty("last_transaction_date")]
    public DateOnly? LastTransactionDate { get; set; }
    /// <summary>
    /// datetime of last successful transaction
    /// </summary>

    [JsonProperty("last_successful_transaction_date")]
    public DateTime? LastSuccessfulTransactionDate { get; set; }

    /// <summary>
    /// 0= not allowed, 1= allowed
    /// </summary>

    [JsonProperty("allow_token_less_access")]
    public sbyte? AllowTokenLessAccess { get; set; }

    public const int NEW_MERCHANT = 1;
    public const int NOT_NEW_MERCHANT = 0;

    public static readonly Dictionary<string, string> MERCHANT_TYPES = new Dictionary<string, string> {
        { "1" , "Corporate" },
        {"2" , "Individual" }
    };

    public const int MERCHANT_BLOCK = 1;
    public const int MERCHANT_NOT_BLOCK = 0;
    public const int LOCAL_MERCHANT_TYPE = 2;
    public const int CORPORATE_MERCHANT_TYPE = 1;
    public const int INDIVIDUAL_MERCHANT_TYPE = 2;
    public const int MARKETPLACE_MERCHANT = 5;
    public const int OXIVO_MERCHANT = 6;
    public const int WALLET_GATE_MERCHANT = 7;
    public const int FASTPAY_WALLET_MERCHANT = 8;
    public const int TAXI_MERCHANT = 9;
    public const int PAVO_MERCHANT = 10;
    public const int API_MERCHANT = 11;
    public const int MT_MERCHANT = 12;
    public const int BILL_PAYMENT_MERCHANT = 13;
    public const int TENANT_MERCHANT = 14;
    public const int COMMISSION = 2;
    public const int ROLLING_STATUS_ACTIVE = 1;
    public const int ROLLING_STATUS_INACTIVE = 0;
    public const int MERCHANT_ACTIVE = 1;
    public const int MERCHANT_INACTIVE = 0;
    public const int INACTIVE_STATUS = 0;
    public const int ACTIVE_STATUS = 1;
    public const int WHITE_LABEL_2D = 0;
    public const int WHITE_LABEL_2D_3D = 1;
    public const int WHITE_LABEL_3D = 2;
    public const int BRANDED = 4;
    public const int DISPLAY_CC_PAGE_AS_POPUP = 5;
    public const int WHITE_LABEL_IFRAME_2D = 6;
    public const int WHITE_LABEL_IFRAME_3D = 7;
    public const int REDIRECTED_WHITE_LABEL = 8;
    public const int SETTLEMENT_TYPE_HOUR = 1;
    public const int SETTLEMENT_TYPE_DAY = 2;
    public const int SETTLEMENT_TYPE_MONTH = 3;
    public const int SETTLEMENT_TYPE_YEAR = 4;
    public const int SETTLEMENT_TYPE_WEEK = 5;

    public static readonly Dictionary<int, string> SETTLEMENT_LIST = new Dictionary<int, string> {
        { SETTLEMENT_TYPE_HOUR , "Hours" },
        { SETTLEMENT_TYPE_DAY , "Days" },
        { SETTLEMENT_TYPE_WEEK , "Weeks" },
        { SETTLEMENT_TYPE_MONTH , "Months" },
        { SETTLEMENT_TYPE_YEAR , "Years" }

    };

    public const int GENERAL_MERCHANT = 0;
    public const int OWN_TEST_MERCHANT = 1;
    public const int CRAFTGATE_MERCHANT = 2;
    public const int DEPOSIT_BY_CREDIT_CARD_PF_MERCHANT = 3;
    public const int TEST_PAYMENT_INTEGRATION_MERCHANT = 4;
    public const int POS_2D = 0;
    public const int POS_3D = 1;
    public const int POS_BOTH_2D_3D = 2;

    public static readonly Dictionary<int, string> ALLOW_POS_OPTION_LIST = new Dictionary<int, string> {
        { POS_2D , "3D’less" },
        { POS_3D , "3D Only" },
        { POS_BOTH_2D_3D , "Allow 2D/3D Payment" }
    };

    public const int TENANT_STATUS_AWAITING = 0;
    public const int TENANT_STATUS_APPROVED = 1;
    public const int TENANT_STATUS_REJECTED = 2;

    public static readonly Dictionary<int, string> TENANT_APPROVAL_STATUS = new Dictionary<int, string> {
        { TENANT_STATUS_AWAITING , "Awaiting" },
        { TENANT_STATUS_APPROVED , "Approved" },
        { TENANT_STATUS_REJECTED , "Rejected" }
    };

    public const int REPORT_MONTHLY_COMMISSION_RECEIPT = 1;
    public const int REPORT_E_INVOICE_MERCHANT = 2;

    public static readonly Dictionary<int, string> MONTHLY_COMMISSION_RECEIPTS = new Dictionary<int, string> {
        { REPORT_MONTHLY_COMMISSION_RECEIPT , "Monthly Commision Receipt Merchant" },
        { REPORT_E_INVOICE_MERCHANT , "e-Invoice Merchant" }
    };
}