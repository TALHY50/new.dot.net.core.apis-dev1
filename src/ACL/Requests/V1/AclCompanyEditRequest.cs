using System.ComponentModel.DataAnnotations;

namespace ACL.Requests.V1
{
    public class AclCompanyEditRequest
    {
        [Required]
        [MaxLength(100)]
        public string cname { get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string cemail { get; set; }

        [Required]
        [MaxLength(100)]
        public string address1 { get; set; }

        [MaxLength(100)]
        public string address2 { get; set; }

        [Required]
        [MaxLength(15)]
        public string city { get; set; }

        [Required]
        [MaxLength(15)]
        public string state { get; set; }

        [Required]
        [MaxLength(100)]
        public string country { get; set; }

        [Required]
        [MaxLength(10)]
        public string postcode { get; set; }

        [Required]
        [MaxLength(15)]
        public string phone { get; set; }

        [Required]
        public int timezone { get; set; }

        [Required]
        public int unique_column_name { get; set; }

        [Required]
        [MaxLength(191)]
        public string logo { get; set; }

        [Required]
        [MaxLength(15)]
        public string fax { get; set; }

        [Required]
        [MaxLength(40)]
        public string registration_no { get; set; }

        [Required]
        [MaxLength(40)]
        public string tax_no { get; set; }

        [Required]
        [MaxLength(20)]
        public string timezone_value { get; set; }

        [Required]
        public sbyte status { get; set; }

        public string name { get; set; }
        //public string prop { get; set; }
    }
}
