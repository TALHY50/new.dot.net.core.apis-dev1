using System.ComponentModel.DataAnnotations.Schema;
using SharedLibrary.Services;
using SharedLibrary.Utilities;

namespace SharedLibrary.Models;
using Newtonsoft.Json;

public partial class Sale
{
    private string _maskedCreditCardNo;
    
    [JsonProperty("id")]
    public uint Id { get; set; }

    [JsonProperty("payment_id")]
    public string? PaymentId { get; set; }

    [JsonProperty("invoice_id")]
    public string? InvoiceId { get; set; }

    [JsonProperty("order_id")]
    public string? OrderId { get; set; }

    [JsonProperty("remote_order_id")]
    public string? RemoteOrderId { get; set; }

    /// <summary>
    /// host_refernce_id from provider response
    /// </summary>
    [JsonProperty("host_reference_id")]
    public string? HostReferenceId { get; set; }

    [JsonProperty("user_id")]
    public int UserId { get; set; }

    [JsonProperty("end_user_id")]
    public int? EndUserId { get; set; }

    [JsonProperty("user_name")]
    public string? UserName { get; set; }

    [JsonProperty("merchant_id")]
    public int MerchantId { get; set; }

    [JsonProperty("merchant_name")]
    public string? MerchantName { get; set; }

    [JsonProperty("transaction_state_id")]
    public int TransactionStateId { get; set; }

    [JsonProperty("purchase_id")]
    public int PurchaseId { get; set; }

    [JsonProperty("gross")]
    public double Gross { get; set; }

    [JsonProperty("refund_request_amount")]
    public double RefundRequestAmount { get; set; }

    [JsonProperty("fee")]
    public double Fee { get; set; }

    /// <summary>
    /// net = gross - fee + user_commission
    /// </summary>
    [JsonProperty("net")]
    public double Net { get; set; }

    /// <summary>
    /// this amount will be calculated from the percentage and fixed on merchant commission tab
    /// </summary>
    [JsonProperty("pay_by_token_fee")]
    public double PayByTokenFee { get; set; }

    [JsonProperty("cost")]
    public double Cost { get; set; }

    [JsonProperty("rolling_amount")]
    public double RollingAmount { get; set; }

    [JsonProperty("product_price")]
    public double ProductPrice { get; set; }

    [JsonProperty("user_commission")]
    public double UserCommission { get; set; }

    [JsonProperty("merchant_commission")]
    public double MerchantCommission { get; set; }

    [JsonProperty("gsm_number")]
    public string? GsmNumber { get; set; }

    [JsonProperty("settlement_date_bank")]
    public DateTime? SettlementDateBank { get; set; }

    [JsonProperty("settlement_date_merchant")]
    public DateTime? SettlementDateMerchant { get; set; }

    /// <summary>
    /// 1=&gt;credit card, 2=&gt; mobile, 3=&gt;wallet, 4=&gt;depositEFT
    /// </summary>
    [JsonProperty("payment_type_id")]
    public sbyte? PaymentTypeId { get; set; }

    [JsonProperty("operator")]
    public string? Operator { get; set; }

    [JsonProperty("issuer_name")]
    public string? IssuerName { get; set; }

    [JsonProperty("card_program")]
    public string? CardProgram { get; set; }

    [JsonProperty("card_issuer_name")]
    public string? CardIssuerName { get; set; }

    [JsonProperty("pos_name")]
    public string? PosName { get; set; }

    [JsonProperty("pos_id")]
    public int? PosId { get; set; }

    [JsonProperty("allocation_id")]
    public int? AllocationId { get; set; }

    [JsonProperty("campaign_id")]
    public int? CampaignId { get; set; }

    [JsonProperty("dpl_id")]
    public int? DplId { get; set; }

    [JsonProperty("json_data")]
    public string? JsonData { get; set; }

    [JsonProperty("document")]
    public string? Document { get; set; }

    [JsonProperty("total_refunded_amount")]
    public double? TotalRefundedAmount { get; set; }

    [JsonProperty("refund_reason")]
    public string? RefundReason { get; set; }

    [JsonProperty("refund_request_date")]
    public DateTime? RefundRequestDate { get; set; }

    [JsonProperty("admin_process_date")]
    public DateTime? AdminProcessDate { get; set; }

    [JsonProperty("chargeback_reject_explanation")]
    public string? ChargebackRejectExplanation { get; set; }

    [JsonProperty("duplicate_invoice_unique_state_key")]
    public string? DuplicateInvoiceUniqueStateKey { get; set; } = null;

    /// <summary>
    /// If duplicate invoice allowed merchant comes with duplicate invoice we will update all the sales with same invoice_id and merchant_id with 1.
    /// 0 = No Duplicate
    /// 1 = Found Duplicate
    /// 2 = Cacnelled In Bank
    /// 3 = Tmp Refund Request Created
    /// </summary>
    [JsonProperty("is_duplicate_invoice")]
    public sbyte? IsDuplicateInvoice { get; set; }

    /// <summary>
    /// To determine if sale settlement is installment wise
    /// </summary>
    [JsonProperty("is_installment_wise_settlement")]
    public bool? IsInstallmentWiseSettlement { get; set; }

    /// <summary>
    /// This is the source to know the initiator of completePayment (2nd step) of a payment model
    /// Complete Payment By
    /// 1 = App
    /// 2 = Merchant
    /// </summary>
    [JsonProperty("payment_completed_by")]
    public sbyte? PaymentCompletedBy { get; set; }

    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [JsonProperty("currency_id")]
    public int? CurrencyId { get; set; }

    [JsonProperty("currency_symbol")]
    public string? CurrencySymbol { get; set; }

    [JsonProperty("installment")]
    public int? Installment { get; set; }

    [JsonProperty("maturity_period")]
    public int? MaturityPeriod { get; set; }

    [JsonProperty("payment_frequency")]
    public int? PaymentFrequency { get; set; }

    [JsonProperty("ip")]
    public string? Ip { get; set; }

    /// <summary>
    /// mdStatus from bank response ranges from 0-9
    /// 0: Card verification failed, do not proceed
    /// 1: Verification successful, you can continue with the transaction
    /// 2: Card holder or bank is not registered in the system
    /// 3: The bank of the card is not registered in the system
    /// 4: Verification attempt, cardholder has chosen to register with the system
    /// later
    /// 5: Unable to verify
    /// 6: 3-D Secure error
    /// 7: System error
    /// 8: Unknown card no
    /// 9: Member Merchant not registered to 3D-Secure system (merchant or
    /// terminal number is not registered on the back as 3d)
    /// </summary>
    [JsonProperty("md_status")]
    public sbyte? MdStatus { get; set; }

    [JsonProperty("result")]
    public string? Result { get; set; }

    [JsonProperty("credit_card_no")]
    public string? CreditCardNo
    {
        get => _maskedCreditCardNo;
        set
        {
            if (value != null) _maskedCreditCardNo = Cryptographer.Mask(value);
        }
    }

    [JsonProperty("card_holder_bank")]
    public string? CardHolderBank { get; set; }

    [JsonProperty("sale_version")]
    public sbyte? SaleVersion { get; set; }

    /// <summary>
    /// 1=auth , 2=PreAuth
    /// </summary>
    [JsonProperty("sale_type")]
    public sbyte? SaleType { get; set; }

    /// <summary>
    /// 1=3D branding and paid by CC, 2= 2D branding and paid by CC, 3 = Mobile payment, 4 = wallet payment, 5 = white label 3D, 6=whiite label 2D, 7 = Redirected white label 3D, 8 = Redirected white label 2D, 9 = DPL 3d, 10 = DPL 2d, 21 = Payment from Wix
    /// </summary>
    [JsonProperty("payment_source")]
    public sbyte PaymentSource { get; set; }

    [JsonProperty("refunded_chargeback_fee")]
    public double? RefundedChargebackFee { get; set; }

    /// <summary>
    /// 0 = not tried yet or pass, 1 = tried and failed
    /// </summary>
    [JsonProperty("is_bank_refund_failed")]
    public sbyte? IsBankRefundFailed { get; set; }

    /// <summary>
    /// 0 = Sale, 1 = Recurring, 2 = DPL
    /// </summary>
    [JsonProperty("recurring_id")]
    public int? RecurringId { get; set; }

    [JsonProperty("sale_web_hook_key")]
    public string? SaleWebHookKey { get; set; }

    [JsonProperty("auth_code")]
    public string? AuthCode { get; set; }

    [JsonProperty("migration_status")]
    public sbyte? MigrationStatus { get; set; }

    /// <summary>
    /// 0 => exiting flow
    /// 1 => new calculation with user fee brutally change
    /// 2 => new calculation with user fee brutally change as zero
    /// </summary>
    [JsonProperty("is_comission_from_user")]
    public sbyte IsComissionFromUser { get; set; }

    [JsonProperty("commission_for_installment")]
    public string? CommissionForInstallment { get; set; }

    [JsonProperty("remote_transaction_datetime")]
    public DateTime? RemoteTransactionDatetime { get; set; }

    /// <summary>
    /// 0 => with cvv
    /// 1 => without cvv
    /// </summary>
    [JsonProperty("is_cvv_less")]
    public sbyte IsCvvLess { get; set; }

    /// <summary>
    /// force chargeback document
    /// </summary>
    [JsonProperty("admin_force_chargeback_document")]
    public string? AdminForceChargebackDocument { get; set; }

    /// <summary>
    /// force chargeback reason
    /// </summary>
    [JsonProperty("admin_force_chargeback_explanation")]
    public string? AdminForceChargebackExplanation { get; set; }

    [JsonProperty("created_at_int")]
    public int? CreatedAtInt { get; set; }

    [JsonProperty("updated_at_int")]
    public int? UpdatedAtInt { get; set; }
    
    
    [NotMapped]
    public string? OriginalBankErrorCode
    {
        get
        {

            string[]? errorDetails = GetErrorDetailsFromResult();
            
                if (errorDetails != null)
                {
                    int index = 2;
                    string originalBankErrorCode = "";
                    if (index < errorDetails.Length)
                    {
                        originalBankErrorCode = errorDetails[index] ?? "";
                    }

                    return originalBankErrorCode.Trim();
                }

                return "";

        }
    }
    
    
     
    [NotMapped]
    public string? OriginalBankErrorDescription
    {
        get
        {

            string[]? errorDetails = GetErrorDetailsFromResult();
            
            if (errorDetails != null)
            {
                int index = 1;
                string originalBankErrorDescription = "";
                if (index < errorDetails.Length)
                {
                    originalBankErrorDescription = errorDetails[index] ?? "";
                }

                return originalBankErrorDescription.Trim();
            }

            return "";

        }
    }

    public bool IsSuccessfulTransaction
    {
        get
        {
            return GetSuccessStates().Contains(TransactionStateId);
        }
    }


    private string[]? GetErrorDetailsFromResult()
    {
        if (this.Result != null)
        {
            string result = ReplaceMiddleContractors(this.Result, '#', '-');

            if (!string.IsNullOrEmpty(result))
            {
                string[]? errorDetails = Str.ToArr(result, '#');

                return errorDetails;

            }

            return null;

        }

        return null;

    }
    
    
   
    
    
    private static string ReplaceMiddleContractors(string val, char contractor, char replaceWith)
    {
        int thisIsFirst = -1;
        int thisIsLast = -1;

        char[] valArray = val.ToCharArray();

        for (int i = 0; i < valArray.Length; i++)
        {
            if (valArray[i] == contractor)
            {
                if (thisIsFirst == -1)
                {
                    thisIsFirst = i;
                }
                else
                {
                    thisIsLast = i;
                    valArray[i] = replaceWith;
                }
            }
        }

        if (thisIsLast > -1)
        {
            valArray[thisIsLast] = contractor;
        }

        return new string(valArray);
    }
    

    public const int PAYMENT_SOURCE_PAID_BY_CC_3D_BRANDING = 1;
    public const int PAYMENT_SOURCE_PAID_BY_CC_2D_BRANDING = 2;
    public const int PAYMENT_SOURCE_MOBILE_PAYMENT = 3;
    public const int PAYMENT_SOURCE_WALLET_PAYMENT = 4;
    public const int PAYMENT_SOURCE_WHITE_LABEL_3D = 5;
    public const int PAYMENT_SOURCE_WHITE_LABEL_2D = 6;
    public const int PAYMENT_SOURCE_REDIRECT_WHITE_LABEL_3D = 7;
    public const int PAYMENT_SOURCE_REDIRECT_WHITE_LABEL_2D = 8;
    public const int PAYMENT_SOURCE_DPL_3D = 9;
    public const int PAYMENT_SOURCE_DPL_2D = 10;
    public const int PAYMENT_SOURCE_MP_3D = 11;
    public const int PAYMENT_SOURCE_MP_2D = 12;
    public const int PAYMENT_SOURCE_PAY_BY_CARDTOKEN_3D = 13;
    public const int PAYMENT_SOURCE_PAY_BY_CARDTOKEN_2D = 14;
    public const int PAYMENT_SOURCE_PAY_BY_MARKETPLACE_3D = 15;
    public const int PAYMENT_SOURCE_PAY_BY_MARKETPLACE_2D = 16;
    public const int PAYMENT_SOURCE_PAY_BY_WIX_3D = 21;
    public const int PAYMENT_SOURCE_PAY_BY_WIX_2D = 22;
    public const int PAYMENT_SOURCE_PAY_BY_REDIRECT_DIRECTLY = 23;
    public const int PAYMENT_SOURCE_ONE_PAGE_PAYMENT_DPL_3D = 24;
    public const int PAYMENT_SOURCE_FASTPAY_WALLET_MOBILE_QR_PAYMENT = 25;
    public const int PAYMENT_SOURCE_OXIVO_PAYMENT = 26; // Physical POS
    public const int PAYMENT_SOURCE_ONE_PAGE_PAYMENT_DPL_2D = 27;
    public const int PAYMENT_SOURCE_FASTPAY_SALE_QR_WALLET = 28;
    public const int PAYMENT_SOURCE_FASTPAY_SALE_QR_NON_SECURE = 29;
    public const int PAYMENT_SOURCE_FASTPAY_SALE_QR_3D_SECURE = 30;
    public const int PAYMENT_SOURCE_DENIZ_DCC_CURRENCY_CONVERSION = 31;
    public const int PAYMENT_SOURCE_RECURRING_PAYMENT = 32;
    public const int PAYMENT_SOURCE_FASTPAY_SALE_MOBILE_WALLET = 33;
    public const int PAYMENT_SOURCE_FASTPAY_SALE_MOBILE_NON_SECURE = 34;
    public const int PAYMENT_SOURCE_FASTPAY_SALE_MOBILE_3D_SECURE = 35;
    public const int PAYMENT_SOURCE_TAXI_YAPIKREDI_TOKEN_PAYMENT = 36; // Physical POS
    public const int PAYMENT_SOURCE_BILL_PAYMENT_PAY_2D = 37;
    public const int PAYMENT_SOURCE_BILL_PAYMENT_PAY_3D = 38;
    public const int PAYMENT_SOURCE_PAVO_PAYMENT = 39; // Physical POS
    public const int PAYMENT_SOURCE_WALLET_PAYMENT_PAY_2D = 40;
    public const int PAYMENT_SOURCE_WALLET_PAYMENT_PAY_3D = 41;
    public const int PAYMENT_SOURCE_INSURANCE_PAYMENT_VIA_IDENTITY_2D = 42;
    public const int PAYMENT_SOURCE_TEST_TRANSACTION_PAY_2D = 43;
    public const int PAYMENT_SOURCE_FP_MT = 44; // Physical POS
    public const int PAYMENT_SOURCE_TENANT_2D = 45;
    public const int PAYMENT_SOURCE_TENANT_3D = 46;
    public const int PAYMENT_SOURCE_HUGIN_PAYMENT = 47; // Physical POS
    public const int PAYMENT_SOURCE_SARI_TAXI_PAYMENT = 48; // Physical POS
    public const sbyte TMP_PAYMENT_TRANS_TYPE_SALE = 1;
    public const int REFUND_NOT_TRIED_OR_PASS = 0;
    public const int REFUND_TRIED_AND_FAILED = 1;
    public const int REFUND_TO_WALLET = 1;
    public const int REFUND_TO_BANK = 2;
    public const int Auth = 1;
    public const int PREAUTH = 2;
    public const int IS_DUPLICATE_INVOICE_NOT_DUPLICATE = 0;
    public const int IS_DUPLICATE_INVOICE_FOUND_DUPLICATE = 1;
    public const int IS_DUPLICATE_INVOICE_CANCELLED_IN_BANK = 2;
    public const int IS_DUPLICATE_INVOICE_TMP_REFUND_REQUEST_CREATED = 3;
    public const int PAYMENT_COMPLETED_BY_APP = 1;
    public const int PAYMENT_COMPLETED_BY_MERCHANT = 2;
    public const int BULK_REFUND_REQUEST_TYPE_SEND_REQUEST_TO_BANK_AGAIN = 0;
    public const int BULK_REFUND_REQUEST_TYPE_CHANGE_AS_REFUNDED = 1;

    public static readonly Dictionary<int, string> BULK_REFUND_REQUEST_TYPES = new Dictionary<int, string>
    {
        { BULK_REFUND_REQUEST_TYPE_SEND_REQUEST_TO_BANK_AGAIN, "Send Request to Bank" },
        { BULK_REFUND_REQUEST_TYPE_CHANGE_AS_REFUNDED, "Change as Refunded" }
    };

    public const int NEW_REFUND_REQUEST = 0;
    public const int MANUAL_BANK_REFUND_REQUEST = 1;

    public static readonly Dictionary<int, string> REFUND_TYPES = new Dictionary<int, string>
    {
        { NEW_REFUND_REQUEST, "New Refund Request" },
        { MANUAL_BANK_REFUND_REQUEST, "Manual Bank Refund Request" }
    };

    public const int MAX_EXPORT_DATA_ROWS = 5;
    public const string REPORT_SERVER_URL = "https://report.sipay.com.tr/merchant/generate-export-url";
    
    
    public static int[] GetSuccessStates()
    {
        int [] successStates =
        {
            TransactionState.COMPLETED,
            TransactionState.REFUNDED,
            TransactionState.PARTIAL_REFUND,
            TransactionState.AWAITINGREFUND,
            TransactionState.RETRY_AWAITING_REFUND,
            TransactionState.CHARGE_BACKED,
            TransactionState.CHARGE_BACK_REQUESTED,
            TransactionState.CHARGE_BACK_REJECTED,
            TransactionState.CHARGE_CANCELED,
            TransactionState.CHARGE_BACK_APPROVED
        };

        return successStates;

    }

}