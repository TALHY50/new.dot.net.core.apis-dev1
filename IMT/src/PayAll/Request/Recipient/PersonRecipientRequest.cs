﻿using System.ComponentModel.DataAnnotations;
using PayAll.Request.PaymentRequest;

namespace PayAll.Request.Recipient
{
    public class PersonRecipientRequest : BaseRecipientRequest
    {
        [Required]
        public string first_name { get; set; }
        [Required]
        public string last_name { get; set; }
        [Required]
        public string middle_name { get; set; }
        [Required]
        public string mobile_number { get; set; }
        public DateOnly dob { get; set; }

        public IdentityDocumentRequest identity_document { get; set; }

      
    }
}
