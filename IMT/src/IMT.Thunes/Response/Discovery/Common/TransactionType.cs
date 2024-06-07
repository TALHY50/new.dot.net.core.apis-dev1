using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMT.Thunes.Response.Discovery.Common
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
}