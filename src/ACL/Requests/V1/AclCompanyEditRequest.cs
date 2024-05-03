using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ACL.Requests.V1
{
    public class AclCompanyEditRequest
    {
        [DefaultValue("mahmud")]
        [Required]
        [MaxLength(100)]
        public string cname { get; set; }

        [DefaultValue("mahmud@gmail.com")]
        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string cemail { get; set; }

        [DefaultValue("Sirajgonj")]
        [Required]
        [MaxLength(100)]
        public string address1 { get; set; }

        [DefaultValue("Dhaka bangladesh")]
        [MaxLength(100)]
        public string address2 { get; set; }

        [DefaultValue("Dhaka")]
        [Required]
        [MaxLength(15)]
        public string city { get; set; }

        [DefaultValue("Dhaka")]
        [Required]
        [MaxLength(15)]
        public string state { get; set; }

        [DefaultValue("Bangladesh")]
        [Required]
        [MaxLength(100)]
        public string country { get; set; }

        [DefaultValue(1229)]
        [Required]
        [MaxLength(10)]
        public string postcode { get; set; }

        [DefaultValue("+880152455")]
        [Required]
        [MaxLength(15)]
        public string phone { get; set; }

        [DefaultValue("+6")]
        [Required]
        public int timezone { get; set; }

        [DefaultValue(1)]
        [Required]
        public int unique_column_name { get; set; }

        [DefaultValue("logon.png")]
        [Required]
        [MaxLength(191)]
        public string logo { get; set; }

        [DefaultValue("+99845")]
        [Required]
        [MaxLength(15)]
        public string fax { get; set; }

        [DefaultValue("5444654")]
        [Required]
        [MaxLength(40)]
        public string registration_no { get; set; }

        [DefaultValue("465456")]
        [Required]
        [MaxLength(40)]
        public string tax_no { get; set; }

        [DefaultValue("bd")]
        [Required]
        [MaxLength(20)]
        public string timezone_value { get; set; }

        [DefaultValue(1)]
        [Required]
        public sbyte status { get; set; }

        [DefaultValue("mahmud")]
        public string name { get; set; }
        //public string prop { get; set; }
    }
}
