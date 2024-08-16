using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace IMT.App.Contracts.Requests
{
    public class QuotationRequest
    {
        [MaxLength(50)]
        public string invoice_id { get; private set; }

        // This property will hold the actual value used internally.
        [JsonProperty("external_id")]
        private string _externalId;

        // Ensure external_id is serialized, but invoice_id is derived from it.
        [JsonIgnore]
        public string external_id
        {
            get
            {
                return _externalId;
            }
            set
            {
                _externalId = value;
                invoice_id = value; // Set invoice_id to the value of external_id
            }
        }

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
