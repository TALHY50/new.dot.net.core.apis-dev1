
using System.ComponentModel.DataAnnotations;
using IMT.PayAll.Model;

namespace IMT.PayAll.Request.Common
{
    public class Amount
    {
        private string _currency;
        [Required]
        [MinLength(3)]
        [MaxLength(3)]
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
        [Required]
        public int value { get; set; }
    }
}
