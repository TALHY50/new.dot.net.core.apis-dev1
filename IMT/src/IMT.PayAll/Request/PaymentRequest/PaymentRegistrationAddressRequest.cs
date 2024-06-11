
using System.ComponentModel.DataAnnotations;


namespace IMT.PayAll.Request.PaymentRequest
{
    public class PaymentRegistrationAddressRequest
    {
        public string city { get; set; }
        public string street { get; set; }
        public string country { get; set; }
        public string postal_code { get; set; }
        public string unit_number { get; set; }
        public string building_name { get; set; }
        public string state_province { get; set; }
        public string building_number { get; set; }


    }
}
