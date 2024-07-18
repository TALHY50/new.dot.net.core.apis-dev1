using System.ComponentModel.DataAnnotations;
using PayAll.Model;
using PayAll.Response.Common;

namespace PayAll.Request.Exchange
{
    public class RequestExchangeRate
    {
        private string? _source_currency;
        private string? _payment_type;
        private string? _payment_instrument_category;
        private string? _target_currency;
        public SourceAmount source_amount { get; set; }
        public TargetAmount target_amount { get; set; }
        public string source_account_id { get; set; }
        [MaxLength(3)]
        [MinLength(3)]
        public string? source_currency
        {
            get => _source_currency;
            set
            {
                if (!string.IsNullOrEmpty(value) && !Enum.GetNames(typeof(Currency)).Contains(value))
                {
                    throw new InvalidOperationException($"Invalid Currency: {value}");
                }
                _source_currency = value;
            }
        }
        public string recipient_instrument_id { get; set; }
        public string? payment_instrument_category
        {
            get => _payment_instrument_category;
            set
            {
                if (!string.IsNullOrEmpty(value) && !Enum.GetNames(typeof(PaymentInstrumentCategory)).Contains(value))
                {
                    throw new InvalidOperationException($"Invalid Payment Instrument Category: {value}");
                }
                _payment_instrument_category = value;
            }
        }
        public string? payment_type
        {
            get => _payment_type;
            set
            {
                if (!string.IsNullOrEmpty(value) && !Enum.GetNames(typeof(PaymentType)).Contains(value))
                {
                    throw new InvalidOperationException($"Invalid Payment Type: {value}");
                }
                _payment_type = value;
            }
        }
        [MaxLength(3)]
        [MinLength(3)]
        public string? target_currency {
            get => _target_currency;
            set
            {
                if (!string.IsNullOrEmpty(value) && !Enum.GetNames(typeof(Currency)).Contains(value))
                {
                    throw new InvalidOperationException($"Invalid Currency: {value}");
                }
                _target_currency = value;
            }
        }
        [RegularExpression("^[A-Z]{2}$", ErrorMessage = "The country code must be exactly two uppercase letters.")]
        public string destination_country { get; set; }


    }

}