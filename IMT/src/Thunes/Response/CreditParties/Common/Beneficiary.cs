namespace Thunes.Response.CreditParties.Common
{
    public class Beneficiary
    {
        public string address { get; set; }
        public string? bank_account_holder_name { get; set; }
        public string city { get; set; }
        public string? code { get; set; }
        public string country_iso_code { get; set; }
        public string country_of_birth_iso_code { get; set; }
        public string date_of_birth { get; set; }
        public string email { get; set; }
        public string firstname { get; set; }
        public string gender { get; set; }
        public string id_country_iso_code { get; set; }
        public DateOnly? id_delivery_date { get; set; }
        public DateOnly? id_expiration_date { get; set; }
        public uint id_number { get; set; }
        public string id_type { get; set; }
        public string lastname { get; set; }
        public string lastname2 { get; set; }
        public string middlename { get; set; }
        public string msisdn { get; set; }
        public string nationality_country_iso_code { get; set; }
        public string nativename { get; set; }
        public string occupation { get; set; }
        public string postal_code { get; set; }
        public string province_state { get; set; }
    }
}