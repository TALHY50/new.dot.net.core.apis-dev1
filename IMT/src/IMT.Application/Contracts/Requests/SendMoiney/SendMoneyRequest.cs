using IMT.Thunes.Request.Transaction.Transfer.CommonTransaction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IMT.Application.Contracts.Requests.SendMoiney
{
    public class SendMoneyRequest
    {
        [MaxLength(50)]
        public string invoice_id { get; set; }

        [MaxLength(50)]
        public string customer_id { get; set; }

        [MaxLength(50)]
        public string payer_id { get; set; }

        [MaxLength(50)]
        public string mode { get; set; }

        [MaxLength(10)]
        public string transaction_type { get; set; }

        public decimal? source_amount { get; set; }

        public string? source_currency_code { get; set; }

        public string? source_country_iso_code { get; set; }

        public decimal? destination_amount { get; set; }

        public string? destination_currency_code { get; set; }

        // Create quoatation request End

        // create money transfer request start
        public CreditPartyIdentifier? credit_party_identifier { get; set; }
        public Beneficiary? beneficiary { get; set; }
        public SendingBusiness? sending_business { get; set; }
        public Sender? sender { get; set; }
        public ReceivingBusinesss? receiving_business { get; set; }
        public string? document_reference_number { get; set; }
        public string? purpose_of_remittance { get; set; }

        public string? callback_url { get; set; }
        public string? retail_fee_currency { get; set; }
        public double? retail_fee { get; set; }

        // create money transfer request end

    }
}