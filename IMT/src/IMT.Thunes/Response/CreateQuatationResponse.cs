using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMT.Thunes.Response.Common;

namespace IMT.Thunes.Response
{
    public class CreateQuatationResponse
    {
        public int id { get; set; }
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