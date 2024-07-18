using System.ComponentModel.DataAnnotations;
using PayAll.Model;

namespace PayAll.Request.PaymentInstructionUpdateRequest
{
    public class UpdateBaseCategory
    {
        private string _category;
        private string _currency;
        [Required]
        public string category
        {
            get => _category;
            set
            {
                if (!string.IsNullOrEmpty(value) && !Enum.GetNames(typeof(PaymentInstrumentCategory)).Contains(value))
                {
                    throw new InvalidOperationException($"Invalid Payment Instrument Category: {value}");
                }
                _category = value;
            }
        }

        [Required]
        public string currency
        {
            get => _currency;
            set
            {
                if (!string.IsNullOrEmpty(value) && !Enum.GetNames(typeof(Currency)).Contains(value))
                {
                    throw new InvalidOperationException($"Invalid Currency: {value}");
                }
                _currency = value;
            }
        }
    }

}