
namespace IMT.PayAll.Request
{
    public class CreatePaymentRequest
    {
        public string client_payment_id { get; set; }
        public Recipient recipient { get; set; }
        public PaymentInstrument payment_instrument { get; set; }
        public string recipient_id { get; set; }
        public string payment_instrument_id { get; set; }
        public string source_account_id { get; set; }
        public Amount amount { get; set; }
        public string exchange_rate_id { get; set; }
        public string carded_rate_id { get; set; }
        public Kyt kyt { get; set; }

    }

    public class Amount
    {
        public string currency { get; set; }
        public int value { get; set; }
    }

    public class IdentityDocument
    {
        public string type { get; set; }
        public string type_version_number { get; set; }
        public string country_issuing { get; set; }
        public string number { get; set; }
        public string national_id_number { get; set; }
        public string national_id_number_type { get; set; }
        public string series { get; set; }
        public DateTime issue_date { get; set; }
        public string place_of_issue { get; set; }
        public string authority_of_issue { get; set; }
        public DateTime expiry_date { get; set; }
        public string driver_license_number { get; set; }
        public string driver_license_serial_number { get; set; }
        public string driver_license_version_number { get; set; }
    }

    public class Kyt
    {
        public string destination_country { get; set; }
        public string payment_purpose { get; set; }
        public string commercial_activity { get; set; }
        public string payment_description { get; set; }
        public List<SupportingDocument> supporting_documents { get; set; }
    }

    public class PaymentInstrument
    {
        public string category { get; set; }
        public string currency { get; set; }
        public string mobile_number { get; set; }
    }

    public class Recipient
    {
        public string type { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string middle_name { get; set; }
        public string mobile_number { get; set; }
        public string dob { get; set; }
        public List<RegistrationAddress> registration_address { get; set; }
        public IdentityDocument identity_document { get; set; }
    }

    public class RegistrationAddress
    {
        public string city { get; set; }
        public string street { get; set; }
        public string country { get; set; }
        public string postal_code { get; set; }
        public string unit_number { get; set; }
        public string building_name { get; set; }
        public string state_province { get; set; }
        public string building_number { get; set; }
    }

    public class SupportingDocument
    {
        public string document_id { get; set; }
    }
}