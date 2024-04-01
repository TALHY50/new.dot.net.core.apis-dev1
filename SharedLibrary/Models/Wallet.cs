using System;
using Newtonsoft.Json;

namespace SharedLibrary.Models
{
    public partial class Wallet
    {
        public const string TYPE_WITHDRAWABLE_AMOUNT = "withdrawable_amount";
        public const string TYPE_NON_WITHDRAWABLE_AMOUNT = "non_withdrawable_amount";
        public const string TYPE_REFUND_PHYSICAL_POS = "refund_physical_pos";
        public const string TYPE_ROLLING_AMOUNT = "rolling_amount";
        public const string TYPE_PRODUCT_SALE = "product_sale";
        public const string TYPE_RESET = "reset";
        public const string TYPE_FORCE_UPDATE_WITHDRAWABLE = "force_update_withdrawable";
        public const string TYPE_FORCE_UPDATE_NON_WITHDRAWABLE = "force_update_non_withdrawable";
        public const string TYPE_TRANSFER = "transfer";
        public const string TYPE_REFUND_DEBIT = "debit";
        public const string TYPE_REFUND_CREDIT = "credit";
        
        //refund_physical_pos rolling_amount

        public const int WITHDRAWABLE_WALLET = 1;
        public const int NON_WITHDRAWABLE_WALLET = 2;

        [JsonProperty("id")]
        public uint Id { get; set; }

        [JsonProperty("user_id")]
        public int UserId { get; set; }

        [JsonProperty("currency_id")]
        public int CurrencyId { get; set; }

        [JsonProperty("amount")]
        public double? Amount { get; set; }

        [JsonProperty("non_withdrawable_amount")]
        public double? NonWithdrawableAmount { get; set; }

        [JsonProperty("withdrawable_amount")]
        public double? WithdrawableAmount { get; set; }

        [JsonProperty("rolling_amount")]
        public double? RollingAmount { get; set; }

        [JsonProperty("pending_sale_amount")]
        public double? PendingSaleAmount { get; set; }

        [JsonProperty("block_amount")]
        public double? BlockAmount { get; set; }

        [JsonProperty("status")]
        public sbyte? Status { get; set; }

        [JsonProperty("allow_cc_deposit")]
        public sbyte? AllowCcDeposit { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}