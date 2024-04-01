namespace SharedLibrary.Models;
using Newtonsoft.Json;

public partial class MerchantSetting
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("merchant_id")]
    public int MerchantId { get; set; }

    [JsonProperty("app_id")]
    public string? AppId { get; set; }

    [JsonProperty("app_secret")]
    public string? AppSecret { get; set; }

    [JsonProperty("return_url")]
    public string? ReturnUrl { get; set; }

    [JsonProperty("save_card_bank_id")]
    public int? SaveCardBankId { get; set; }

    [JsonProperty("recurring_web_hook")]
    public string? RecurringWebHook { get; set; }

    [JsonProperty("sale_web_hook")]
    public string? SaleWebHook { get; set; }

    [JsonProperty("timezone")]
    public string? Timezone { get; set; }

    [JsonProperty("wallet_status")]
    public sbyte WalletStatus { get; set; }

    [JsonProperty("credit_card_status")]
    public sbyte CreditCardStatus { get; set; }

    [JsonProperty("mobile_payment_status")]
    public sbyte MobilePaymentStatus { get; set; }

    /// <summary>
    /// 0=&gt;do not show, 1=&gt; show
    /// </summary>
    [JsonProperty("is_show_installment_table")]
    public sbyte IsShowInstallmentTable { get; set; }

    /// <summary>
    /// One Time DPL Link=1, Multi Time DPL Link=2, One Page DPL Link=3
    /// </summary>
    [JsonProperty("default_dpl_link_type")]
    public sbyte DefaultDplLinkType { get; set; }

    /// <summary>
    /// 0 =&gt; By Default ... Not Checked DPL Take Commission From User, 1 =&gt; Checked DPL Take Commission From User, 
    /// </summary>
    [JsonProperty("is_checked_dpl_take_commission_from_user")]
    public sbyte IsCheckedDplTakeCommissionFromUser { get; set; }

    /// <summary>
    /// 0 =&gt; By Default ... Not Checked DPL Amount Decide By User, 1=&gt; Auto Checked DPL Amount Decide By User, 
    /// </summary>
    [JsonProperty("is_checked_dpl_amount_decide_by_user")]
    public sbyte IsCheckedDplAmountDecideByUser { get; set; }

    [JsonProperty("wix_merchant_id")]
    public string? WixMerchantId { get; set; }

    /// <summary>
    /// 1 = enable, 0= disable
    /// </summary>
    [JsonProperty("is_enable_wallet_service")]
    public sbyte IsEnableWalletService { get; set; }

    /// <summary>
    /// 0 =&gt; not allow , 1 =&gt; allow
    /// </summary>
    [JsonProperty("is_allow_2d_cvvless")]
    public sbyte IsAllow2dCvvless { get; set; }

    /// <summary>
    /// 0 =&gt; not allow , 1 =&gt; allow 
    /// </summary>
    [JsonProperty("is_allow_3d_cvvless")]
    public sbyte IsAllow3dCvvless { get; set; }

    /// <summary>
    /// To check if merchant is allowed to do insurance payment
    /// 0 = Not Allowed
    /// 1 = Allowed
    /// </summary>
    [JsonProperty("is_allow_insurance_payment")]
    public sbyte? IsAllowInsurancePayment { get; set; }

    /// <summary>
    /// To check if merchant is allowed for currency conversion flow 
    /// 0 = Not Allowed
    /// 1 = Allowed
    /// </summary>
    [JsonProperty("is_allow_russian_bin_to_ruble")]
    public sbyte? IsAllowRussianBinToRuble { get; set; }

    /// <summary>
    /// 0 = not  allow,  1=allow
    /// </summary>
    [JsonProperty("is_allow_dcc")]
    public sbyte? IsAllowDcc { get; set; }

    /// <summary>
    /// 0 =&gt; not allow , 1 =&gt; allow 
    /// </summary>
    [JsonProperty("is_visa_allow")]
    public sbyte IsVisaAllow { get; set; }

    /// <summary>
    /// 0 =&gt; not master card allow , 1 =&gt; master card allow 
    /// </summary>
    [JsonProperty("is_master_card_allow")]
    public sbyte IsMasterCardAllow { get; set; }

    /// <summary>
    /// 0=not allowed, 1= allowed
    /// </summary>
    [JsonProperty("is_allow_cashout_request")]
    public sbyte? IsAllowCashoutRequest { get; set; }

    /// <summary>
    /// 1 = Enable IP Restriction,  0 = Disable IP Restriction
    /// </summary>
    [JsonProperty("is_enable_ip_restriction")]
    public sbyte? IsEnableIpRestriction { get; set; }

    /// <summary>
    /// 0=not allowed, 1= allowed
    /// </summary>
    [JsonProperty("is_allow_tarim")]
    public sbyte? IsAllowTarim { get; set; }

    [JsonProperty("min_installment_no_of_business_cards")]
    public int MinInstallmentNoOfBusinessCards { get; set; }

    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// 0=not allowed, 1= allowed
    /// </summary>
    [JsonProperty("is_allow_dpl")]
    public sbyte? IsAllowDpl { get; set; }

    /// <summary>
    /// 0=not allowed, 1= allowed
    /// </summary>
    [JsonProperty("is_allow_manual_pos")]
    public sbyte? IsAllowManualPos { get; set; }

    /// <summary>
    /// 0=not allowed, 1= allowed
    /// </summary>
    [JsonProperty("is_allow_one_page_payment")]
    public sbyte? IsAllowOnePagePayment { get; set; }

    /// <summary>
    /// 0=not allowed, 1= allowed
    /// </summary>
    [JsonProperty("is_allow_recurring_payment")]
    public sbyte? IsAllowRecurringPayment { get; set; }

    /// <summary>
    /// 0=not allowed, 1=all
    /// </summary>
    [JsonProperty("is_physical_pos_allow")]
    public sbyte? IsPhysicalPosAllow { get; set; }

    /// <summary>
    /// 0=not allowed, 1=allow
    /// </summary>
    [JsonProperty("is_allow_pre_auth")]
    public sbyte? IsAllowPreAuth { get; set; }

    /// <summary>
    /// 0=not allowed, 1=allow
    /// </summary>
    [JsonProperty("is_allow_bill_payment")]
    public sbyte? IsAllowBillPayment { get; set; }

    /// <summary>
    /// 0=2d, 1=3D, 2=Allow 2D And 3D
    /// </summary>
    [JsonProperty("dpl_pos_option")]
    public sbyte? DplPosOption { get; set; }

    /// <summary>
    /// 0=2d, 1=3D, 2=Allow 2D And 3D
    /// </summary>
    [JsonProperty("manual_pos_options")]
    public sbyte? ManualPosOptions { get; set; }

    /// <summary>
    /// 0 = do not send  1 = send email
    /// </summary>
    [JsonProperty("is_receive_balance_update_email")]
    public sbyte? IsReceiveBalanceUpdateEmail { get; set; }

    /// <summary>
    /// 1=&gt; Monthly Commision Receipt, 2=&gt;e-Invoice Merchant
    /// </summary>
    [JsonProperty("commission_receipt_type")]
    public sbyte? CommissionReceiptType { get; set; }

    /// <summary>
    /// 0=not allowed, 1=allowed
    /// </summary>
    [JsonProperty("is_allow_virtual_card")]
    public sbyte IsAllowVirtualCard { get; set; }

    /// <summary>
    /// 0=not allowed, 1=allowed
    /// </summary>
    [JsonProperty("is_allow_withdrawal")]
    public sbyte IsAllowWithdrawal { get; set; }

    /// <summary>
    /// To check if merchant is allowed for installment wise settlement
    /// 0 : Not Allowed
    /// 1 : Allowed
    /// </summary>
    [JsonProperty("is_installment_wise_settlement")]
    public bool? IsInstallmentWiseSettlement { get; set; }

    /// <summary>
    /// 0 = not exempted (will check for block card cc); 1 = exempted (special merchant will not check the block card cc)
    /// </summary>
    [JsonProperty("is_exempt_card_block")]
    public sbyte IsExemptCardBlock { get; set; }

    [JsonProperty("is_allow_automatic_ftp_report")]
    public sbyte IsAllowAutomaticFtpReport { get; set; }

    /// <summary>
    /// 0=&gt;not allowed, 1=&gt;allowed
    /// </summary>
    [JsonProperty("is_allowed_hugin")]
    public sbyte IsAllowedHugin { get; set; }

    /// <summary>
    /// 0=&gt;not allowed, 1=&gt;allowed
    /// </summary>
    [JsonProperty("is_allow_sari_taxi")]
    public bool IsAllowSariTaxi { get; set; }

    /// <summary>
    /// merchant for test purpose
    /// </summary>
    [JsonProperty("is_test_merchant")]
    public bool IsTestMerchant { get; set; }

    /// <summary>
    /// 0 = not allowed, 1 = allowed
    /// </summary>
    [JsonProperty("is_allow_oxivo")]
    public bool IsAllowOxivo { get; set; }

    /// <summary>
    /// 0 = not allowed, 1 = allowed
    /// </summary>
    [JsonProperty("is_allow_pavo")]
    public bool IsAllowPavo { get; set; }

    /// <summary>
    /// 0 = not allowed, 1 = allowed
    /// </summary>
    [JsonProperty("is_allow_mt")]
    public bool IsAllowMt { get; set; }

    /// <summary>
    /// Control to refund/cancel success payment from checkOrderStatus/checkSpecialOrderStatus cronjob/queue unitOfWork
    /// Values: 0 : Not Allowed, 1 : Allowed 
    /// </summary>
    [JsonProperty("is_allow_avoid_pending_payment")]
    public bool? IsAllowAvoidPendingPayment { get; set; }
}