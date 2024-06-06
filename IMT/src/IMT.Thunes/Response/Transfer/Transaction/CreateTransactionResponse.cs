using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMT.Thunes.Response.Transfer.Transaction
{
    public class CreateTransactionResponse
    {
        public int id { get; set; }
        public string status { get; set; }
        public string status_message { get; set; }
        public string status_class { get; set; }
        public string status_class_message { get; set; }
        public string external_id { get; set; }
        public object external_code { get; set; }
        public string transaction_type { get; set; }
        public object payer_transaction_reference { get; set; }
        public object payer_transaction_code { get; set; }
        public DateTime creation_date { get; set; }
        public DateTime expiration_date { get; set; }
        public CreditPartyIdentifier credit_party_identifier { get; set; }
        public Source source { get; set; }
        public Destination destination { get; set; }
        public Payer payer { get; set; }
        public Sender sender { get; set; }
        public Beneficiary beneficiary { get; set; }
        public string callback_url { get; set; }
        public SentAmount sent_amount { get; set; }
        public double wholesale_fx_rate { get; set; }
        public object retail_rate { get; set; }
        public int retail_fee { get; set; }
        public string retail_fee_currency { get; set; }
        public Fee fee { get; set; }
        public string purpose_of_remittance { get; set; }
        public string document_reference_number { get; set; }
        public object additional_information_1 { get; set; }
        public object additional_information_2 { get; set; }
        public object additional_information_3 { get; set; }
        public object reference { get; set; }
    }



    #region SubOrdinate Response For Create Transaction

    public class Beneficiary
    {
        public string lastname { get; set; }
        public object lastname2 { get; set; }
        public object middlename { get; set; }
        public string firstname { get; set; }
        public object nativename { get; set; }
        public string nationality_country_iso_code { get; set; }
        public object code { get; set; }
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
        public object id_delivery_date { get; set; }
        public object id_expiration_date { get; set; }
        public string occupation { get; set; }
        public object bank_account_holder_name { get; set; }
        public object province_state { get; set; }
    }

    public class CreditPartyIdentifier
    {
        public string msisdn { get; set; }
        public string bank_account_number { get; set; }
        public string swift_bic_code { get; set; }
    }

    public class Destination
    {
        public string currency { get; set; }
        public double amount { get; set; }
    }

    public class Fee
    {
        public string currency { get; set; }
        public double amount { get; set; }
    }

    public class Payer
    {
        public int id { get; set; }
        public string name { get; set; }
        public string currency { get; set; }
        public string country_iso_code { get; set; }
        public Service service { get; set; }
    }

    public class Sender
    {
        public string lastname { get; set; }
        public object lastname2 { get; set; }
        public object middlename { get; set; }
        public string firstname { get; set; }
        public object nativename { get; set; }
        public string nationality_country_iso_code { get; set; }
        public object code { get; set; }
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
        public object id_country_iso_code { get; set; }
        public string id_number { get; set; }
        public string id_delivery_date { get; set; }
        public object id_expiration_date { get; set; }
        public string occupation { get; set; }
        public object province_state { get; set; }
        public object beneficiary_relationship { get; set; }
        public object source_of_funds { get; set; }
        public object bank_account_number { get; set; }
    }

    public class SentAmount
    {
        public string currency { get; set; }
        public int amount { get; set; }
    }

    public class Service
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Source
    {
        public string country_iso_code { get; set; }
        public string currency { get; set; }
        public int amount { get; set; }
    }

    #endregion
}
