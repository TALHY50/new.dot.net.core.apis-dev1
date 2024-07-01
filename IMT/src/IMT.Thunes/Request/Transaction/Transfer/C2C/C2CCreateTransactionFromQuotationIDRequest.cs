//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace IMT.Thunes.Request.Transaction.Transfer.C2C
//{
//    public class C2CCreateTransactionFromQuotationIDRequest
//    {
//        public CreditPartyIdentifier credit_party_identifier { get; set; }
//        public Beneficiary beneficiary { get; set; }
//        public Sender sender { get; set; }
//        public long external_id { get; set; }
//    }

//    public class Beneficiary
//    {
//        public string lastname { get; set; }
//        public string firstname { get; set; }
//    }

//    public class CreditPartyIdentifier
//    {
//        public string iban { get; set; }
//    }
//    public class Sender
//    {
//        public string address { get; set; }
//        public string country_iso_code { get; set; }
//        public string lastname { get; set; }
//        public string city { get; set; }
//        public string firstname { get; set; }
//        public string country_of_birth_iso_code { get; set; }
//        public string date_of_birth { get; set; }
//        public string code { get; set; }
//    }


//}