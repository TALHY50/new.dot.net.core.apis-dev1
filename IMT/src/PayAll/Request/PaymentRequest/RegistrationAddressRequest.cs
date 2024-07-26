
using System.ComponentModel.DataAnnotations;

namespace PayAll.Request.PaymentRequest
{
    public class RegistrationAddressRequest
    {
        [Required]
        [MaxLength(35)]
        public string city { get; set; }
        [Required]
        [MaxLength(35)]
        public string street { get; set; }
        [Required]
        [MaxLength(255)]
        public string country { get; set; }
        [MaxLength(50)]
        public string postal_code { get; set; }
        [MaxLength(20)]
        public string unit_number { get; set; }
        [MaxLength(255)]
        public string building_name { get; set; }
        [MaxLength(255)]
        public string state_province { get; set; }
        [MaxLength(20)]
        public string building_number { get; set; }


    }
}
