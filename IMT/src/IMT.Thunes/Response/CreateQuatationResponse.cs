using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMT.Thunes.Response.Common;

namespace IMT.Thunes.Response
{
    public class CreateQuatationResponse
    {
        public int Id { get; set; }
        public string ExternalId { get; set; }
        public Payer Payer { get; set; }
        public string Mode { get; set; }
        public string TransactionType { get; set; }
        public Source Source { get; set; }
        public Destination Destination { get; set; }
        public SentAmount SentAmount { get; set; }
        public double WholesaleFxRate { get; set; }
        public Fee Fee { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}