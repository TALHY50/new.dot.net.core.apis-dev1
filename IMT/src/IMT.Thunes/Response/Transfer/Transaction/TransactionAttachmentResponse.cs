using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMT.Thunes.Response.Transfer.Transaction
{
    public class TransactionAttachmentResponse
    {
        public int id { get; set; }
        public string content_type { get; set; }
        public string name { get; set; }
        public int transaction_id { get; set; }
        public string type { get; set; }
    }
}
