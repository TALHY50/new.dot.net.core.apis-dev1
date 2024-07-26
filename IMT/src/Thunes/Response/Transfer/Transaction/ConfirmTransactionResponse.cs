namespace Thunes.Response.Transfer.Transaction
{
    public class ConfirmTransactionResponse
    {
        public object? additional_information_1 { get; set; }
        public object? additional_information_2 { get; set; }
        public object? additional_information_3 { get; set; }
        public object? callback_url { get; set; }
        public DateTime creation_date { get; set; }
        public CreditPartyIdentifierConfirm credit_party_identifier { get; set; }
        public DestinationConfirm destination { get; set; }
        public string document_reference_number { get; set; }
        public DateTime expiration_date { get; set; }
        public object? external_code { get; set; }
        public string external_id { get; set; }
        public FeeConfirm fee { get; set; }
        public int id { get; set; }
        public PayerConfirm payer { get; set; }
        public object? payer_transaction_code { get; set; }
        public object? payer_transaction_reference { get; set; }
        public string purpose_of_remittance { get; set; }
        public ReceivingBusiness receiving_business { get; set; }
        public object? reference { get; set; }
        public object? retail_fee { get; set; }
        public object? retail_fee_currency { get; set; }
        public object? retail_rate { get; set; }
        public SendingBusiness sending_business { get; set; }
        public SentAmountConfirm sent_amount { get; set; }
        public SourceConfirm source { get; set; }
        public string status { get; set; }
        public string status_class { get; set; }
        public string status_class_message { get; set; }
        public string status_message { get; set; }
        public string transaction_type { get; set; }
        public double wholesale_fx_rate { get; set; }
    }

    public class CreditPartyIdentifierConfirm
    {
        public string? iban { get; set; }
    }

    public class DestinationConfirm
    {
        public double? amount { get; set; }
        public string currency { get; set; }
    }

    public class FeeConfirm
    {
        public double? amount { get; set; }
        public string currency { get; set; }
    }

    public class PayerConfirm
    {
        public string country_iso_code { get; set; }
        public string currency { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public ServiceConfirm service { get; set; }
    }

    public class ReceivingBusiness
    {
        public object address { get; set; }
        public object city { get; set; }
        public object code { get; set; }
        public string country_iso_code { get; set; }
        public object date_of_incorporation { get; set; }
        public object email { get; set; }
        public object msisdn { get; set; }
        public object postal_code { get; set; }
        public object province_state { get; set; }
        public string registered_name { get; set; }
        public object registration_number { get; set; }
        public object representative_firstname { get; set; }
        public object representative_id_country_iso_code { get; set; }
        public object representative_id_delivery_date { get; set; }
        public object representative_id_expiration_date { get; set; }
        public object representative_id_number { get; set; }
        public object representative_id_type { get; set; }
        public object representative_lastname { get; set; }
        public object representative_lastname2 { get; set; }
        public object representative_middlename { get; set; }
        public object representative_nativename { get; set; }
        public object tax_id { get; set; }
        public object trading_name { get; set; }
    }

    public class SendingBusiness
    {
        public object address { get; set; }
        public object business_relationship { get; set; }
        public object city { get; set; }
        public string code { get; set; }
        public string country_iso_code { get; set; }
        public object date_of_incorporation { get; set; }
        public object email { get; set; }
        public object msisdn { get; set; }
        public object postal_code { get; set; }
        public object province_state { get; set; }
        public string registered_name { get; set; }
        public string registration_number { get; set; }
        public object representative_firstname { get; set; }
        public object representative_id_country_iso_code { get; set; }
        public object representative_id_delivery_date { get; set; }
        public object representative_id_expiration_date { get; set; }
        public object representative_id_number { get; set; }
        public object representative_id_type { get; set; }
        public object representative_lastname { get; set; }
        public object representative_lastname2 { get; set; }
        public object representative_middlename { get; set; }
        public object representative_nativename { get; set; }
        public object tax_id { get; set; }
        public object trading_name { get; set; }
    }

    public class SentAmountConfirm
    {
        public double amount { get; set; }
        public string currency { get; set; }
    }

    public class ServiceConfirm
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class SourceConfirm
    {
        public double amount { get; set; }
        public string country_iso_code { get; set; }
        public string currency { get; set; }
    }

}
