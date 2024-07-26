namespace Thunes.Response.Discovery.Common
{
    public class TransactionType
    {
        public decimal minimum_transaction_amount;
        public decimal? maximum_transaction_amount;
        public List<List<string>> credit_party_identifiers_accepted;
        public List<List<string>> required_sending_entity_fields;
        public List<List<string>> required_receiving_entity_fields;
        public List<List<string>> required_documents;
        public CreditPartyInformation credit_party_information;
        public CreditPartyVerification credit_party_verification;
        public List<string> purpose_of_remittance_values_accepted;

    }

    public class TransactionTypes
    {
        public B2B B2B { get; set; }
        public B2C B2C { get; set; }
        public C2C C2C { get; set; }
    }

      public class B2B
    {
        public List<List<string>> credit_party_identifiers_accepted { get; set; }
        public CreditPartyInformation credit_party_information { get; set; }
        public CreditPartyVerification credit_party_verification { get; set; }
        public object maximum_transaction_amount { get; set; }
        public string minimum_transaction_amount { get; set; }
        public List<object> purpose_of_remittance_values_accepted { get; set; }
        public List<List<object>> required_documents { get; set; }
        public List<List<string>> required_receiving_entity_fields { get; set; }
        public List<List<string>> required_sending_entity_fields { get; set; }
    }

    public class B2C
    {
        public List<List<string>> credit_party_identifiers_accepted { get; set; }
        public CreditPartyInformation credit_party_information { get; set; }
        public CreditPartyVerification credit_party_verification { get; set; }
        public object maximum_transaction_amount { get; set; }
        public string minimum_transaction_amount { get; set; }
        public List<object> purpose_of_remittance_values_accepted { get; set; }
        public List<List<object>> required_documents { get; set; }
        public List<List<string>> required_receiving_entity_fields { get; set; }
        public List<List<string>> required_sending_entity_fields { get; set; }
    }

    public class C2C
    {
        public List<List<string>> credit_party_identifiers_accepted { get; set; }
        public CreditPartyInformation credit_party_information { get; set; }
        public CreditPartyVerification credit_party_verification { get; set; }
        public object maximum_transaction_amount { get; set; }
        public string minimum_transaction_amount { get; set; }
        public List<object> purpose_of_remittance_values_accepted { get; set; }
        public List<List<object>> required_documents { get; set; }
        public List<List<string>> required_receiving_entity_fields { get; set; }
        public List<List<string>> required_sending_entity_fields { get; set; }
    }

    //public class CreditPartyInformation
    //{
    //    public List<List<object>> credit_party_identifiers_accepted { get; set; }
    //}

    //public class CreditPartyVerification
    //{
    //    public List<List<object>> credit_party_identifiers_accepted { get; set; }
    //    public List<List<object>> required_receiving_entity_fields { get; set; }
    //}
}