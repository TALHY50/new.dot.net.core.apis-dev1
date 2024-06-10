﻿

using System.ComponentModel.DataAnnotations;

namespace IMT.PayAll.Request.Payer
{
    public class BusinessPayerRequest : BasePayerRequest
    {
        [Required]
        public string legal_name { get; set; }
        [Required]
        public string country { get; set; }
        [Required]
        public string trade_name { get; set; }
        [Required]
        public string phone_number { get; set; }
        [Required]
        public string registration_number { get; set; }

       
    }
}