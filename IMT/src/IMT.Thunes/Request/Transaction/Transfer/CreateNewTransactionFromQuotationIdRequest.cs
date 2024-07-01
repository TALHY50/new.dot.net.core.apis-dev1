using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMT.Thunes.Request.Transaction.Transfer
{
    public class CreateNewTransactionFromQuotationIdRequest
    {
        public string external_id { get; set; }
        public SendingBusinessQuotationId sending_business { get; set; }
        public string document_reference_number { get; set; }
        public string purpose_of_remittance { get; set; }
        public ReceivingBusinessQuotationId receiving_business { get; set; }
        public CreditPartyIdentifierWithQotationId credit_party_identifier { get; set; }
    }
    public class CreditPartyIdentifierWithQotationId
    {
        public string iban { get; set; }
    }

    public class ReceivingBusinessQuotationId
    {
        public string registered_name { get; set; }
        public string country_iso_code { get; set; }
    }
    public class SendingBusinessQuotationId
    {
        public string country_iso_code { get; set; }
        public string code { get; set; }
        public string registered_name { get; set; }
        public string registration_number { get; set; }
    }
}
