using Newtonsoft.Json;

namespace SharedLibrary.Models;
public partial class TmpSaleAutomation
{
    public int Id { get; set; }

    [JsonProperty("sale_id")]
    public int SaleId { get; set; }

    [JsonProperty("transaction_state_id")]
    public int TransactionStateId { get; set; }

    [JsonProperty("is_save_card")]
    public sbyte? IsSaveCard { get; set; }

    [JsonProperty("is_save_card_processed")]
    public sbyte? IsSaveCardProcessed { get; set; }

    [JsonProperty("is_call_sale_webhook")]
    public sbyte? IsCallSaleWebhook { get; set; }

    [JsonProperty("is_call_sale_webhook_processed")]
    public sbyte? IsCallSaleWebhookProcessed { get; set; }

    [JsonProperty("is_ip_to_country")]
    public sbyte? IsIpToCountry { get; set; }

    [JsonProperty("is_ip_to_country_processed")]
    public sbyte? IsIpToCountryProcessed { get; set; }

    [JsonProperty("is_send_to_payer")]
    public sbyte? IsSendToPayer { get; set; }

    [JsonProperty("is_send_to_payer_processed")]
    public sbyte? IsSendToPayerProcessed { get; set; }

    [JsonProperty("is_send_puchase_email")]
    public sbyte? IsSendPuchaseEmail { get; set; }

    [JsonProperty("is_send_puchase_email_processed")]
    public sbyte? IsSendPuchaseEmailProcessed { get; set; }

    [JsonProperty("is_send_sms")]
    public sbyte? IsSendSms { get; set; }

    [JsonProperty("is_send_sms_processed")]
    public sbyte? IsSendSmsProcessed { get; set; }

    [JsonProperty("is_first_transaction_alert")]
    public sbyte? IsFirstTransactionAlert { get; set; }

    [JsonProperty("is_first_transaction_alert_processed")]
    public sbyte? IsFirstTransactionAlertProcessed { get; set; }

    [JsonProperty("is_process_fail_alert")]
    public sbyte? IsProcessFailAlert { get; set; }

    [JsonProperty("is_process_fail_alert_processed")]
    public sbyte? IsProcessFailAlertProcessed { get; set; }

    [JsonProperty("is_wix")]
    public sbyte IsWix { get; set; }

    [JsonProperty("is_wix_processed")]
    public sbyte? IsWixProcessed { get; set; }

    [JsonProperty("is_manual_pos")]
    public sbyte? IsManualPos { get; set; }

    [JsonProperty("is_manual_pos_processed")]
    public sbyte? IsManualPosProcessed { get; set; }

    [JsonProperty("pay_by_card_token_provider")]
    public string? PayByCardTokenProvider { get; set; }

    [JsonProperty("is_send_craft_gate_payment_response_processed")]
    public sbyte? IsSendCraftGatePaymentResponseProcessed { get; set; }

    [JsonProperty("sale_obj")]
    public string? SaleObj { get; set; }

    [JsonProperty("bank_obj")]
    public string? BankObj { get; set; }

    [JsonProperty("merchant_obj")]
    public string? MerchantObj { get; set; }

    [JsonProperty("merchant_user_obj")]
    public string? MerchantUserObj { get; set; }

    [JsonProperty("sale_billing_obj")]
    public string? SaleBillingObj { get; set; }

    [JsonProperty("sale_billing_data")]
    public string? SaleBillingData { get; set; }

    [JsonProperty("purchase_request_obj")]
    public string? PurchaseRequestObj { get; set; }

    [JsonProperty("currency_obj")]
    public string? CurrencyObj { get; set; }

    [JsonProperty("dpl_obj")]
    public string? DplObj { get; set; }

    [JsonProperty("user_obj")]
    public string? UserObj { get; set; }

    [JsonProperty("extras")]
    public string? Extras { get; set; }

    /// <summary>
    /// increase every time. after 3 times, change status = 2
    /// </summary>
    [JsonProperty("attempt")]
    public sbyte? Attempt { get; set; }

    /// <summary>
    ///  0=pending, 1=processed, 2=awaiting state for deleting
    /// </summary>
    [JsonProperty("status")]
    public sbyte? Status { get; set; }

    /// <summary>
    /// 1 = do not send any notification or webhook,
    /// 0 =  Send notification and webhook
    /// </summary>
    [JsonProperty("is_notification_off")]
    public sbyte? IsNotificationOff { get; set; }

    [JsonProperty("is_tax_info")]
    public sbyte? IsTaxInfo { get; set; }

    [JsonProperty("is_tax_info_processed")]
    public sbyte? IsTaxInfoProcessed { get; set; }

    [JsonProperty("version")]
    public sbyte? Version { get; set; }

    [JsonProperty("is_last_row")]
    public sbyte? IsLastRow { get; set; }

    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTime? UpdatedAt { get; set; }
}
