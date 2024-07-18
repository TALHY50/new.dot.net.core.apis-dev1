

using System.ComponentModel.DataAnnotations;
using IMT.PayAll.Request.PaymentRequest;

namespace IMT.PayAll.Request.Payer
{
    public class PersonPayerRequest : BasePayerRequest
    {
        [Required]
        public string first_name { get; set; }
        [Required]
        public string middle_name { get; set; }
        [Required]
        public string last_name { get; set; }
     
        [Required]
        public string phone_number { get; set; }
      
        public string nationality { get; set; }
        [Required]
        public string government_id { get; set; }
        [Required]
        public DateOnly date_of_birth { get; set; }
        public string source_of_income { get; set; }
        public string place_of_birth { get; set; }
        public string occupation { get; set; }
        public string relationship_with_beneficiary { get; set; }
      
    }
}
