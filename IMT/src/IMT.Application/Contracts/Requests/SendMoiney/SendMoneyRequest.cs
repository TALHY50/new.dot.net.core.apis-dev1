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
        // Create quoatation request start
        [Required]
        [MaxLength(50)]
        public string OrderId { get; set; }

        [Required]
        [MaxLength(50)]
        public string PayerId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Mode { get; set; }

        [Required]
        [MaxLength(10)]
        public string TransactionType { get; set; }

        public decimal? SourceAmount { get; set; }

        public int? ImtSourceCurrencyId { get; set; }

        public int? ImtProviderId { get; set; }

        public int? ImtProviderServiceId { get; set; }

        public int? ImtSourceCountryId { get; set; }

        public decimal? DestinationAmount { get; set; }

        public int? ImtDestinationCurrencyId { get; set; }

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