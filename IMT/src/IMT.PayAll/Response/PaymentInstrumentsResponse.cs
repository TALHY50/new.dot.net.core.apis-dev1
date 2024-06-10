

namespace IMT.PayAll.Response
{
    public class PaymentInstrumentsResponse
    {
        public Guid id { get; set; }
        public string category { get; set; }
        public string currency { get; set; }
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
        public string token { get; set; }
        public string masked_number { get; set; }
        public string expiration_date { get; set; }

    }
   

}
