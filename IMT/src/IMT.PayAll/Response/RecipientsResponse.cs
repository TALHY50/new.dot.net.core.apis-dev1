

namespace IMT.PayAll.Response
{
    public class RecipientsResponse
    {
        public string id { get; set; }
        public string type { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string middle_name { get; set; }
        public string mobile_number { get; set; }
        public string dob { get; set; }
        public object registration_address { get; set; }
        public IdentityDocument identity_document { get; set; }
        public string legal_name { get; set; }
        public string country { get; set; }
        public string trade_name { get; set; }
        public string phone_number { get; set; }
        public string registration_number { get; set; }
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

}
