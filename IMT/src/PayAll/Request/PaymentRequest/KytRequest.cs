using System.ComponentModel.DataAnnotations;
using PayAll.Model;
using PayAll.Request.Common;

namespace PayAll.Request.PaymentRequest
{
    public class KytRequest
    {
        private string _payment_purpose;
        private string _commercial_activity;

        [Required]
        [RegularExpression("^[A-Z]{2}$", ErrorMessage = "The country code must be exactly two uppercase letters.")]
        public string destination_country { get; set; }
        [Required]
        public string payment_purpose 
        {
            get => _payment_purpose; 
            set
            {
                if (!string.IsNullOrEmpty(value) && !Enum.GetNames(typeof(PaymentPurpose)).Contains(value))
                {
                    throw new InvalidOperationException($"Invalid Payment Purpose: {value}");
                }
                _payment_purpose = value;
            }
        }
        [Required]
        public string commercial_activity
        {
            get => _commercial_activity;
            set
            {
                if (!string.IsNullOrEmpty(value) && !Enum.GetNames(typeof(CommercialActivity)).Contains(value))
                {
                    throw new InvalidOperationException($"Invalid Commercial Activity: {value}");
                }
                _commercial_activity = value;
            }
        }
        [Required]
        public string payment_description { get; set; }
        public List<SupportingDocument> supporting_documents { get; set; }
    }

}
