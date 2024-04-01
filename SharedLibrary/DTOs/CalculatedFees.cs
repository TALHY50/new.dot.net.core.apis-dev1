using Newtonsoft.Json;

namespace SharedLibrary.DTOs;

public class CalculatedFees
{
    [JsonProperty("amount")]
    public decimal Amount { get; set;}
    
    [JsonProperty("fee")]
    public decimal Fee { get; set; }

    [JsonProperty("cost")]
    public decimal Cost { get; set; }
    
    [JsonProperty("gross")]
    public decimal Gross { get; set;}

    [JsonProperty("net")]
    public decimal Net { get; set; }

    [JsonProperty("user_fee")]
    public decimal UserFee { get; set; }

    [JsonProperty("merchant_fee")]
    public decimal MerchantFee { get; set; }

    [JsonProperty("merchant_commission_percentage")]
    public decimal MerchantCommissionPercentage { get; set; }

    [JsonProperty("merchant_commission_fixed")]
    public decimal MerchantCommissionFixed { get; set; }

    [JsonProperty("brand_cot_percentage")]
    public decimal BrandCotPercentage { get; set; }

    [JsonProperty("brand_cot_fixed")]
    public decimal BrandCotFixed { get; set; }

    [JsonProperty("exchange_rate")]
    public decimal? ExchangeRate { get; set; }

    [JsonProperty("end_user_commission_percentage")]
    public decimal EndUserCommissionPercentage { get; set; }

    [JsonProperty("end_user_commission_fixed")]
    public decimal EndUserCommissionFixed { get; set; }

    [JsonProperty("merchant_refund_commission")]
    public decimal MerchantRefundCommission { get; set; }

    [JsonProperty("merchant_refund_commission_fixed")]
    public decimal MerchantRefundCommissionFixed { get; set; }

    [JsonProperty("merchant_chargeback_commission")]
    public decimal MerchantChargebackCommission { get; set; }

    [JsonProperty("merchant_chargeback_commission_fixed")]
    public decimal MerchantChargebackCommissionFixed { get; set; }
    
    
    [JsonProperty("settlement_amount")]
    public decimal SettlementAmount { get; set; }
    
    [JsonProperty("merchant_rolling_percentage")]
    
    public decimal MerchantRollingPercentage { get; set;}
    
    [JsonProperty("rolling_amount")]
    public decimal RollingAmount { get; set; }
    
    [JsonProperty("pay_by_token_percentage")]
    public decimal PayByTokenPercentage { get; set; }
    
    
    [JsonProperty("pay_by_token_fixed")]
    public decimal PayByTokenFixed { get; set; }

    
    [JsonProperty("allow_pay_by_token_refund_fee")]
    public int AllowPayByTokenFee { get; set; }


    [JsonProperty("pay_by_token_fee")]
    public decimal PayByTokenFee { get; set; }

    
}
