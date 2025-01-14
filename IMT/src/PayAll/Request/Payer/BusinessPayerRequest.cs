﻿

using System.ComponentModel.DataAnnotations;

namespace PayAll.Request.Payer
{
    public class BusinessPayerRequest : BasePayerRequest
    {
        [Required]
        public string legal_name { get; set; }
        public string trade_name { get; set; }
        [Required]
        [RegularExpression("^[A-Z]{2}$", ErrorMessage = "The country code must be exactly two uppercase letters.")]
        public string country { get; set; }
        [Required]
        public string registration_number { get; set; }
        [MaxLength(30)]
        public string phone_number { get; set; }
        public DateOnly registration_date { get; set; }


       
    }
}
