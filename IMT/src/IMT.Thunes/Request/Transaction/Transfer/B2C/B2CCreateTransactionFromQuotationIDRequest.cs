using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMT.Thunes.Request.Transaction.Transfer.B2C
{
    public class B2CCreateTransactionFromQuotationIDRequest
    {

        public long external_id { get; set; }
        public Beneficiary beneficiary { get; set; }
        public SendingBusiness sending_business { get; set; }
        public CreditPartyIdentifier credit_party_identifier { get; set; }
    }

    public class Beneficiary
    {
        public string firstname { get; set; }
        public string country_iso_code { get; set; }
        public string lastname { get; set; }
    }

    public class CreditPartyIdentifier
    {
        public string iban { get; set; }
    }
    public class SendingBusiness
    {
        public string code { get; set; }
        public string country_iso_code { get; set; }
        public string registered_name { get; set; }
        public string registration_number { get; set; }
    }



}