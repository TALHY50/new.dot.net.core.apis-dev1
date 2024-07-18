

namespace IMT.PayAll.Request.PaymentRequest
{
    public class BankAccountRequest : BaseCategory
    {
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

    }

   
}