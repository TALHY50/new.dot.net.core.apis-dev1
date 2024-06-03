using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMT.Thunes.Request
{
    public class CreateNewTransactionRequest
    {
        public CreditPartyIdentifier credit_party_identifier { get; set; }
        public Sender sender { get; set; }
        public Beneficiary beneficiary { get; set; }
        public string external_id { get; set; }
        public int retail_fee { get; set; }
        public string retail_fee_currency { get; set; }
        public string purpose_of_remittance { get; set; }
        public string document_reference_number { get; set; }
        public string callback_url { get; set; }
        public string reference { get; set; }
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
    #endregion

}
