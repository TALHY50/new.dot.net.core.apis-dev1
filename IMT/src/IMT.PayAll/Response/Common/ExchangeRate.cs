using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMT.PayAll.Response.Common
{
    public class ExchangeRate
    {
        public string id { get; set; }
        public SourceAmount source_amount { get; set; }
        public TargetAmount target_amount { get; set; }
        public DateTime expiration_date { get; set; }
    }
}
