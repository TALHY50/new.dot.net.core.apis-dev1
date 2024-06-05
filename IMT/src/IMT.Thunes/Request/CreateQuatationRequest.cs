using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMT.Thunes.Request.Common;

namespace IMT.Thunes.Request
{
    public class CreateQuatationRequest
    {
        public string external_id { get; set; }
        public string payer_id { get; set; }
        public string mode { get; set; }
        public string transaction_type { get; set; }
        public Source1 source { get; set; }
        public Destination1 destination { get; set; }
    }
}