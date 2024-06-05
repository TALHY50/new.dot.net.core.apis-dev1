using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMT.PayAll.Request.Common;

namespace IMT.PayAll.Request.PaymentRequest
{
    public class Kyt
    {
        public string destination_country { get; set; }
        public string payment_purpose { get; set; }
        public string commercial_activity { get; set; }
        public string payment_description { get; set; }
        public List<SupportingDocument> supporting_documents { get; set; }
    }

}
