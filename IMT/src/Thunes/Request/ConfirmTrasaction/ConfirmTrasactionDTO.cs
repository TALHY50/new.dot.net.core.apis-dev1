using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMT.Thunes.Request.ConfirmTrasaction
{
    public class ConfirmTrasactionDTO
    {
        public string InvoiceId { get; set; }
        public int RemoteTrasactionId { get; set; }
        public int ProviderId { get; set; }
        public sbyte Type { get; set; }
    }
}
