using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMT.Application.Contracts.Requests.Quotation
{
    public class QuotationRequest
    {
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

    }
}
