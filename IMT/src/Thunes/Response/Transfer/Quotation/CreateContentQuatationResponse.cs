using Newtonsoft.Json;
using Destination = Thunes.Response.Common.Destination;
using Fee = Thunes.Response.Common.Fee;
using Payer = Thunes.Response.Common.Payer;
using SentAmount = Thunes.Response.Common.SentAmount;
using Source = Thunes.Response.Common.Source;

namespace Thunes.Response.Transfer.Quotation
{
    public class CreateContentQuotationResponse
    {
        public ulong id { get; set; }
        [JsonProperty("invoice_id")]
        public string invoice_id
        {
            get { return external_id; }
            set { external_id = value; }
        }

        //[JsonIgnore]
        public string external_id { get; set; }
        public Payer payer { get; set; }
        public string mode { get; set; }
        public string transaction_type { get; set; }
        public Source source { get; set; }
        public Destination destination { get; set; }
        public SentAmount sent_amount { get; set; }
        public double wholesale_fx_rate { get; set; }
        public Fee fee { get; set; }
        public DateTime creation_date { get; set; }
        public DateTime expiration_date { get; set; }
    }
}