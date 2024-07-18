

using System.ComponentModel.DataAnnotations;
using IMT.PayAll.Model;
using IMT.PayAll.Request.PaymentRequest;

namespace IMT.PayAll.Request.Recipient
{
    public class BaseRecipientRequest
    {
        private string _type;
        [Required]
        public string type
        {
            get => _type;
            set
            {
                if (!Enum.GetNames(typeof(AccountType)).Contains(value))
                {
                    throw new InvalidOperationException($"Invalid AccountType: {value}");
                }
                _type = value;
            }
        }
        [Required]
        public string email { get; set; }
        public List<RegistrationAddressRequest> registration_address { get; set; }

        
    }
}
