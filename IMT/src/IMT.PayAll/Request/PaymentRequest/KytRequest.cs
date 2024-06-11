using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMT.PayAll.Request.Common;

namespace IMT.PayAll.Request.PaymentRequest
{
    public class KytRequest
    {
        [Required]
        public string destination_country { get; set; }
        [Required]
        public string payment_purpose { get; set; }
        [Required]
        public string commercial_activity { get; set; }
        [Required]
        public string payment_description { get; set; }
        public List<SupportingDocument> supporting_documents { get; set; }
    }

}
