namespace IMT.App.Contracts.Requests
{
    public class MoneyTransferRequest
    {
        public int id { get; set; }

        public string? payment_id { get; set; }

        public int? transaction_state_id { get; set; }

        public int? reason_id { get; set; }

        public int? payment_method_id { get; set; }

        /// <summary>
        /// 1=instant, 2=regular, 3=same_day etc.
        /// </summary>
        public sbyte? transfer_type { get; set; }

        public string? reason_code { get; set; }

        /// <summary>
        /// type 1 = b2b, 2 = c2c, 3=c2b, 4=b2c etc
        /// </summary>
        public sbyte? type { get; set; }

        public string? sender_name { get; set; }

        public string? receiver_name { get; set; }

        public string? sender_currency_code { get; set; }

        public string? receiver_currency_code { get; set; }

        public decimal? exchange_rate { get; set; }

        public decimal? send_amount { get; set; }

        public decimal? receive_amount { get; set; }

        public decimal? exchanged_amount { get; set; }

        public decimal? fee { get; set; }

        public decimal? vat { get; set; }

        public string? commission_paid_by { get; set; }

        public int? sender_customer_id { get; set; }

        public int? receiver_customer_id { get; set; }

        public string? source { get; set; }

        public string? order_id { get; set; }

        public string? remote_order_id { get; set; }

        public string? invoice_id { get; set; }
    }
}
