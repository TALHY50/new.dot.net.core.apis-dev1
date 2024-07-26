using PayAll.Model;

namespace PayAll.Request.PaymentRequest
{
    public class PaymentInstrumentRequest
    {
        private string _category;
        private string _currency;
       
        public string category
        {
            get => _category;
            set
            {
                if (!string.IsNullOrEmpty(value) && !Enum.GetNames(typeof(PaymentInstrumentCategory)).Contains(value))
                {
                    throw new InvalidOperationException($"Invalid Payment Instrument Category: {value}");
                }
                _category = value;
            }
        }

       
        public string currency
        {
            get => _currency;
            set
            {
                if (!string.IsNullOrEmpty(value) && !Enum.GetNames(typeof(Currency)).Contains(value))
                {
                    throw new InvalidOperationException($"Invalid Currency: {value}");
                }
                _currency = value;
            }
        }

        public string mobile_number { get; set; }

        public string routing_number { get; set; }
        public string swift_bic_code { get; set; }
        public string bank_domestic_code { get; set; }
        public string iban { get; set; }
        public string swift_intermediary { get; set; }
        public string routing_number_intermediary { get; set; }
        public string iban_intermediary { get; set; }
        public string account_id { get; set; }
        public string bank_name { get; set; }
        public string bank_branch_name { get; set; }
        public string bank_country { get; set; }
        public string bank_address { get; set; }
        public string account_number { get; set; }
        public string sub_account_number { get; set; }
        public string account_type { get; set; }
        public string account_name { get; set; }
        public string urgency_flag_preference { get; set; }

        public string first_name { get; set; }
        public string last_name { get; set; }
    }

}
