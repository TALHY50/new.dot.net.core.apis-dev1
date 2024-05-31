using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMT.Thunes.Request.Common;

namespace IMT.Thunes.Request
{
    public class CreateQuatationRequest
    {
        public  string ExternalId { get; set; }
        public  string PayerId { get; set; }
        public  string Mode { get; set; }
        public  string TransactionType { get; set; }
        public  Source Source { get; set; }
        public  Destination Destination { get; set; }
    }
}