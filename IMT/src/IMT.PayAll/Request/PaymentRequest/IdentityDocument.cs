using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMT.PayAll.Request.PaymentRequest
{
    public class IdentityDocument
    {
        public string type { get; set; }
        public string type_version_number { get; set; }
        public string country_issuing { get; set; }
        public string number { get; set; }
        public string national_id_number { get; set; }
        public string national_id_number_type { get; set; }
        public string series { get; set; }
        public DateTime issue_date { get; set; }
        public string place_of_issue { get; set; }
        public string authority_of_issue { get; set; }
        public DateTime expiry_date { get; set; }
        public string driver_license_number { get; set; }
        public string driver_license_serial_number { get; set; }
        public string driver_license_version_number { get; set; }
    }
}
