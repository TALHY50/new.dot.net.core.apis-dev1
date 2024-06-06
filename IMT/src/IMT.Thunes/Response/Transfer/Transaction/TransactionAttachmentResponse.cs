using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMT.Thunes.Response.Transfer.Transaction
{
    public class TransactionAttachmentResponse
    {
        public int Id { get; set; }
        public string ContentType { get; set; }
        public string Name { get; set; }
        public int TransactionId { get; set; }
        public string Type { get; set; }
    }
}
