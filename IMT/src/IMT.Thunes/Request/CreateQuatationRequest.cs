using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMT.Thunes.Request.Common;

namespace IMT.Thunes.Request
{
    public class CreateQuatationRequest
    {
        public required string ExternalId { get; set; }
        public required string PayerId { get; set; }
        public required string Mode { get; set; }
        public required string TransactionType { get; set; }
        public required Source Source { get; set; }
        public required Destination Destination { get; set; }
    }
}