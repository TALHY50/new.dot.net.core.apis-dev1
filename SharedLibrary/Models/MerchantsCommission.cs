using Newtonsoft.Json;

namespace SharedLibrary.Models;
public partial class MerchantsCommission
{
    public int Id { get; set; }

    [JsonProperty("merchant_id")]
    public int MerchantId { get; set; }

    /// <summary>
    /// 1=Credit Card;2=>Mobile Payment;3=>Sipay Wallet
    /// </summary>
    [JsonProperty("payment_type_id")]
    public sbyte PaymentTypeId { get; set; }

    /// <summary>
    /// 0=>N/A;1=>wirecard;
    /// </summary>
    [JsonProperty("provider")]
    public sbyte? Provider { get; set; }

    /// <summary>
    /// 1=>Turkcell;2=>Vodafone;3=>Turk Telekom;
    /// </summary>
    [JsonProperty("operator")]
    public sbyte? Operator { get; set; }

    [JsonProperty("service_id")]
    public int ServiceId { get; set; }

    [JsonProperty("cot_percentage")]
    public double CotPercentage { get; set; }

    [JsonProperty("cot_fixed")]
    public double CotFixed { get; set; }

    [JsonProperty("merchant_commission")]
    public double? MerchantCommission { get; set; }

    [JsonProperty("user_commission")]
    public double? UserCommission { get; set; }

    [JsonProperty("currency_id")]
    public int? CurrencyId { get; set; }

    [JsonProperty("merchant_commission_fixed")]
    public double? MerchantCommissionFixed { get; set; }

    [JsonProperty("user_commission_fixed")]
    public double? UserCommissionFixed { get; set; }

    [JsonProperty("b2c_commission")]
    public double? B2cCommission { get; set; }

    [JsonProperty("b2b_commission")]
    public double? B2bCommission { get; set; }

    [JsonProperty("settlement_id")]
    public int? SettlementId { get; set; }

    [JsonProperty("single_payment_settlement_id")]
    public int? SinglePaymentSettlementId { get; set; }

    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// 0=inactive; 1=active
    /// </summary>
    [JsonProperty("active_status")]
    public sbyte? ActiveStatus { get; set; }

    /// <summary>
    /// 0 =is_foreign_card_commission_enable inactive ; 1 = is_foreign_card_commission_enable active
    /// </summary>
    [JsonProperty("is_foreign_card_commission_enable")]
    public sbyte? IsForeignCardCommissionEnable { get; set; }

    [JsonProperty("refund_commission")]
    public double? RefundCommission { get; set; }

    [JsonProperty("refund_commission_fixed")]
    public double? RefundCommissionFixed { get; set; }

    [JsonProperty("chargeback_commission")]
    public double? ChargebackCommission { get; set; }

    [JsonProperty("chargeback_commission_fixed")]
    public double? ChargebackCommissionFixed { get; set; }

    [JsonProperty("is_enable_pay_by_token")]
    public sbyte? IsEnablePayByToken { get; set; }

    [JsonProperty("pay_by_token_commission")]
    public double? PayByTokenCommission { get; set; }

    [JsonProperty("pay_by_token_fixed")]
    public double? PayByTokenFixed { get; set; }

    [JsonProperty("is_enable_taxi_commission")]
    public sbyte? IsEnableTaxiCommission { get; set; }

    [JsonProperty("taxi_commission_percentage")]
    public double? TaxiCommissionPercentage { get; set; }

    [JsonProperty("taxi_commission_fixed")]
    public double? TaxiCommissionFixed { get; set; }

    [JsonProperty("is_enable_ykb_commission")]
    public sbyte? IsEnableYkbCommission { get; set; }

    [JsonProperty("ykb_commission_percentage")]
    public double? YkbCommissionPercentage { get; set; }

    [JsonProperty("ykb_commission_fixed")]
    public double? YkbCommissionFixed { get; set; }

    /// <summary>
    /// 0 =fee back disable ; 1 = fee back enable
    /// </summary>
    [JsonProperty("allow_pay_by_token_refund_fee")]
    public sbyte? AllowPayByTokenRefundFee { get; set; }

    [JsonProperty("is_debit_card_commission_enable")]
    public sbyte? IsDebitCardCommissionEnable { get; set; }

    [JsonProperty("merchant_debit_card_commission_percentage")]
    public double? MerchantDebitCardCommsissionPercentage { get; set; }

    [JsonProperty("merchant_debit_card_commission_fixed")]
    public double? MerchantDebitCardCommsissionFixed { get; set; }

    [JsonProperty("user_debit_card_commission_percentage")]
    public double? UserDebitCardCommsissionPercentage { get; set; }

    [JsonProperty("user_debit_card_commission_fixed")]
    public double? UserDebitCardCommsissionFixed { get; set; }

    /// <summary>
    /// Determine Imported Transaction(like Oxivo, Pavo etc) Commission is enabled or not.
    /// </summary>
    [JsonProperty("is_enable_imported_transaction_commission")]
    public bool? IsEnableImportedTransactionCommission { get; set; }

    /// <summary>
    /// Commission Percentage Of Imported Transactions
    /// </summary>
    [JsonProperty("imported_transaction_commission_percentage")]
    public double ImportedTransactionCommissionPercentage { get; set; }

    /// <summary>
    /// Commission Fixed Of Imported Transactions
    /// </summary>
    [JsonProperty("imported_transaction_commission_fixed")]
    public double ImportedTransactionCommissionFixed { get; set; }

    /// <summary>
    /// cost of transaction percentage of imported transaction
    /// </summary>
    [JsonProperty("imported_transaction_cot_percentage")]
    public double ImportedTransactionCotPercentage { get; set; }

    /// <summary>
    /// cost of transaction fixed of imported transaction
    /// </summary>
    [JsonProperty("imported_transaction_cot_fixed")]
    public double ImportedTransactionCotFixed { get; set; }
}
