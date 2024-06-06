using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace IMT.Thunes.Request.Transaction
{
    public class CreateNewTransactionRequest
    {
        public required CreditPartyIdentifier credit_party_identifier { get; set; }
        public required Sender sender { get; set; }
        public required Beneficiary beneficiary { get; set; }
        public required SendingBussiness sending_business { get; set; }
        public required RecievingBussiness receiving_business { get; set; }
        public required string external_id { get; set; }
        public string? external_code { get; set; }
        public decimal? retail_fee { get; set; }
        public decimal? retail_rate { get; set; }
        public string? retail_fee_currency { get; set; }
        public required string purpose_of_remittance { get; set; }
        public string? document_reference_number { get; set; }
        public string? callback_url { get; set; }
        public string? reference { get; set; }
        public string? additional_information_1 { get; set; }
        public string? additional_information_2 { get; set; }
        public string? additional_information_3 { get; set; }
    }




    #region SubOrdinate Class
    public class Beneficiary
    {
        public string lastname { get; set; }
        public string firstname { get; set; }
        public string nationality_country_iso_code { get; set; }
        public string date_of_birth { get; set; }
        public string country_of_birth_iso_code { get; set; }
        public string gender { get; set; }
        public string address { get; set; }
        public string postal_code { get; set; }
        public string city { get; set; }
        public string country_iso_code { get; set; }
        public string msisdn { get; set; }
        public string email { get; set; }
        public string id_type { get; set; }
        public string id_country_iso_code { get; set; }
        public string id_number { get; set; }
        public string occupation { get; set; }
    }

    public class CreditPartyIdentifier
    {
        public string msisdn { get; set; }
        public string bank_account_number { get; set; }
        public string swift_bic_code { get; set; }
    }

    public class Sender
    {
        public string lastname { get; set; }
        public string firstname { get; set; }
        public string nationality_country_iso_code { get; set; }
        public string date_of_birth { get; set; }
        public string country_of_birth_iso_code { get; set; }
        public string gender { get; set; }
        public string address { get; set; }
        public string postal_code { get; set; }
        public string city { get; set; }
        public string country_iso_code { get; set; }
        public string msisdn { get; set; }
        public string email { get; set; }
        public string id_type { get; set; }
        public string id_number { get; set; }
        public string id_delivery_date { get; set; }
        public string occupation { get; set; }
    }

    public class RecievingBussiness
    {
        public string? registered_name { get; set; }
        public string? trading_name { get; set; }
        public string? address { get; set; }
        public string? postal_code { get; set; }
        public string? city { get; set; }
        public string? province_state { get; set; }
        public string? country_iso_code { get; set; }
        public string? msisdn { get; set; }
        public string? email { get; set; }
        public string? registration_number { get; set; }
        public string? tax_id { get; set; }
        public string? date_of_incorporation { get; set; }
        public string? representative_lastname { get; set; }
        public string? representative_lastname2 { get; set; }
        public string? representative_firstname { get; set; }
        public string? representative_middlename { get; set; }
        public string? representative_nativename { get; set; }
        public string? representative_id_type { get; set; }
        public string representative_id_country_iso_code { get; set; }
        public string? representative_id_number { get; set; }
        public string? representative_id_delivery_date { get; set; }
        public string? representative_id_expiration_date { get; set; }
    }

    public class SendingBussiness : RecievingBussiness
    {
        public string? code { get; set; }
        public string? business_relationship { get; set; }
    }


    #endregion

}
