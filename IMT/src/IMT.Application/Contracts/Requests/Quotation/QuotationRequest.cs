using System.ComponentModel.DataAnnotations;

namespace IMT.Application.Contracts.Requests.Quotation
{
    public class QuotationRequest
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

    }
}
