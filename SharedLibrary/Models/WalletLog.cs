using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedLibrary.Models;

public partial class WalletLog
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string? EventName { get; set; }

    public string? EffectAmount { get; set; }

    public string? EffectWithdrawableAmount { get; set; }

    public string? EffectNonwithdrawableAmount { get; set; }

    public string? EffectRollingAmount { get; set; }

    public int CurrencyId { get; set; }

    public double BeforeAmount { get; set; }

    public double AfterAmount { get; set; }

    public double BeforeWithdrawableAmount { get; set; }

    public double AfterWithdrawableAmount { get; set; }

    public double BeforeNonwithdrawableAmount { get; set; }

    public double AfterNonwithdrawableAmount { get; set; }

    public double BeforeRollingAmount { get; set; }

    public double? AfterRollingAmount { get; set; }

    public string EffectPendingSaleAmount { get; set; }

    public double BeforePendingSaleAmount { get; set; }

    public double AfterPendingSaleAmount { get; set; }

    public double BlockAmount { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ActionName { get; set; }

    [NotMapped]
    public string? BeforeLog { get; set; }
    [NotMapped]
    public string? AfterLog { get; set; }

    public string? PaymentId { get; set; }

    public string? ReferenceType { get; set; }

    public int? ReferenceId { get; set; }

    public string? UniqueString { get; set; }

    public sbyte? MigrationStatus { get; set; }

    [NotMapped]
    [JsonIgnore]
    public Wallet? BeforeWallet { get; set; }

    [NotMapped]
    [JsonIgnore]
    public Wallet? AfterWallet { get; set; }

    [NotMapped]
    public string UniqueId { get; set; }
}




public class TextWalletLog
{
    [JsonProperty("action")]
    public string Action { get; set; }

    [JsonProperty("user_id")]
    public string UserId { get; set; }

    [JsonProperty("currency_id")]
    public int CurrencyId { get; set; }

    [JsonProperty("total")]
    public decimal? Total { get; set; }

    [JsonProperty("withdrawable_amount")]
    public decimal? WithdrawableAmount { get; set; }

    [JsonProperty("non_withdrawable_amount")]
    public decimal? NonWithdrawableAmount { get; set; }

    [JsonProperty("rolling_amount")]
    public decimal? RollingAmount { get; set; }

    [JsonProperty("pending_sale_amount")]
    public decimal? PendingSaleAmount { get; set; }

    [JsonProperty("created_on")]
    public DateTime? CreatedOn { get; set; }

    [JsonProperty("debit_amount")]
    public decimal? DebitAmount { get; set; }

    [JsonProperty("credit_amount")]
    public decimal? CreditAmount { get; set; }

    [JsonProperty("type")]
    public string? Type { get; set; }

    [JsonProperty("refund_net_amount")]
    public decimal? RefundNetAmount { get; set; }

    [JsonProperty("refund_rolling_amount")]
    public decimal? RefundRollingAmount { get; set; }

    [JsonProperty("refund_withdrawable_amount")]
    public decimal? RefundWithdrawableAmount { get; set; }
}
