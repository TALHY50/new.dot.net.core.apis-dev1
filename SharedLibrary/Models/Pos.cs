using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedLibrary.Models;

[Table("Pos")]
public partial class Pos
{
    public int Id { get; set; }

    [JsonProperty("pos_id")]
    public int? PosId { get; set; }

    [JsonProperty("virtual_pos_id")]
    public string? VirtualPosId { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("settlement_id")]
    public sbyte SettlementId { get; set; }

    [JsonProperty("refund_settlement_id")]
    public sbyte RefundSettlementId { get; set; }

    [JsonProperty("foreign_card_settlement_id")]
    public sbyte ForeignCardSettlementId { get; set; }

    [JsonProperty("bank_id")]
    public int? BankId { get; set; }

    [JsonProperty("bank_name")]
    public string? BankName { get; set; }

    [JsonProperty("on_us_cc_cot_percentage")]
    public double OnUsCcCotPercentage { get; set; }

    [JsonProperty("on_us_cc_cot_fixed")]
    public double OnUsCcCotFixed { get; set; }

    [JsonProperty("not_us_cc_cot_percentage")]
    public double NotUsCcCotPercentage { get; set; }

    [JsonProperty("not_us_cc_cot_fixed")]
    public double NotUsCcCotFixed { get; set; }

    [JsonProperty("debit_cot_percentage")]
    public double DebitCotPercentage { get; set; }

    [JsonProperty("debit_cot_fixed")]
    public double DebitCotFixed { get; set; }

    [JsonProperty("not_us_debit_cot_percentage")]
    public double NotUsDebitCotPercentage { get; set; }

    [JsonProperty("not_us_debit_cot_fixed")]
    public double NotUsDebitCotFixed { get; set; }

    [JsonProperty("foreign_cc_cot_percentage")]
    public double? ForeignCcCotPercentage { get; set; }

    [JsonProperty("foreign_cc_cot_fixed")]
    public double? ForeignCcCotFixed { get; set; }

    [JsonProperty("foreign_amex_cot_percentage")]
    public double? ForeignAmexCotPercentage { get; set; }

    [JsonProperty("foreign_amex_cot_fixed")]
    public double? ForeignAmexCotFixed { get; set; }

    [JsonProperty("local_amex_cot_percentage")]
    public double? LocalAmexCotPercentage { get; set; }

    [JsonProperty("local_amex_cot_fixed")]
    public double? LocalAmexCotFixed { get; set; }

    [JsonProperty("same_program_same_bank_cot_percentage")]
    public double? SameProgramSameBankCotPercentage { get; set; }

    [JsonProperty("same_program_same_bank_cot_fixed")]
    public double? SameProgramSameBankCotFixed { get; set; }

    [JsonProperty("same_program_diffrent_bank_cot_percentage")]
    public double? SameProgramDiffrentBankCotPercentage { get; set; }

    [JsonProperty("same_program_diffrent_bank_cot_fixed")]
    public double? SameProgramDiffrentBankCotFixed { get; set; }

    [JsonProperty("currency_id")]
    public sbyte? CurrencyId { get; set; }

    [JsonProperty("min_installment")]
    public sbyte MinInstallment { get; set; }

    [JsonProperty("max_installment")]
    public sbyte MaxInstallment { get; set; }

    [JsonProperty("program")]
    public string? Program { get; set; }

    [JsonProperty("bolum")]
    public sbyte Bolum { get; set; }

    [JsonProperty("status")]
    public sbyte Status { get; set; }

    /// <summary>
    /// 0 = dont send, 1 = send
    /// </summary>
    [JsonProperty("send_pf_records")]
    public sbyte? SendPfRecords { get; set; }

    /// <summary>
    /// 1=enable; 0=disable
    /// </summary>
    [JsonProperty("is_enable_2d")]
    public sbyte? IsEnable2d { get; set; }

    /// <summary>
    /// 1=enable; 0=disable
    /// </summary>
    [JsonProperty("is_enable_3d")]
    public sbyte? IsEnable3d { get; set; }

    /// <summary>
    /// 0 =allow_foreign_card inactive; 1= allow_foreign_card active
    /// </summary>
    [JsonProperty("allow_foreign_card")]
    public sbyte? AllowForeignCard { get; set; }

    /// <summary>
    /// 0 = auth ; 1 = pre_auth
    /// </summary>
    [JsonProperty("is_allow_pre_auth")]
    public sbyte? IsAllowPreAuth { get; set; }

    /// <summary>
    /// 0 = not  allow,  1=allow
    /// </summary>
    [JsonProperty("is_allow_dcc")]
    public sbyte? IsAllowDcc { get; set; }

    /// <summary>
    /// 0 = not  allow,  1=allow
    /// </summary>
    [JsonProperty("is_allow_local_amex_card")]
    public sbyte? IsAllowLocalAmexCard { get; set; }

    /// <summary>
    /// 0 = not  allow,  1=allow
    /// </summary>
    [JsonProperty("is_allow_foreign_amex_card")]
    public sbyte? IsAllowForeignAmexCard { get; set; }

    [JsonProperty("is_recurring")]
    public sbyte? IsRecurring { get; set; }

    [JsonProperty("is_show_on_deposit")]
    public sbyte? IsShowOnDeposit { get; set; }

    [JsonProperty("is_allow_sale")]
    public sbyte? IsAllowSale { get; set; }

    /// <summary>
    /// To check if POS is allowed for insurance payment
    /// 0 : Not Allowed
    /// 1 : Allowed
    /// </summary>
    [JsonProperty("is_allow_insurance_payment")]
    public sbyte? IsAllowInsurancePayment { get; set; }

    /// <summary>
    /// To check if POS is allowed for installment wise settlement
    /// 0 : Not Allowed
    /// 1 : Allowed
    /// </summary>
    [JsonProperty("is_installment_wise_settlement")]
    public sbyte? IsInstallmentWiseSettlement { get; set; }

    [JsonProperty("allow_pay_by_card_token")]
    public sbyte? AllowPayByCardToken { get; set; }

    [JsonProperty("remote_sub_merchant_id")]
    public string? RemoteSubMerchantId { get; set; }

    [JsonProperty("max_no_of_failed_attempt")]
    public int MaxNoOfFailedAttempt { get; set; }

    [JsonProperty("created_by_id")]
    public int? CreatedById { get; set; }

    [JsonProperty("updated_by_id")]
    public int? UpdatedById { get; set; }

    [JsonProperty("bank_closing_time")]
    public TimeOnly? BankClosingTime { get; set; }

    /// <summary>
    /// id from brand_bank_accounts table where pos account is true
    /// </summary>
    [JsonProperty("brand_bank_account_id")]
    public int? BrandBankAccountId { get; set; }

    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTime? UpdatedAt { get; set; }
    public static readonly sbyte SEND_PF_RECORDS = 1;
    public static readonly sbyte DO_NOT_SEND_PF_RECORDS = 0;
}
