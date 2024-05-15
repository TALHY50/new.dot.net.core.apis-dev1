using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ACL.Contracts.Requests.V1
{
    public class AclCompanyCreateRequest
    {
        [DefaultValue("Mahmud")]
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [DefaultValue("mahmud@gmail.com")]
        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Cemail { get; set; }

        [DefaultValue("Sirajgonj")]
        [Required]
        [MaxLength(100)]
        public string Address1 { get; set; }

        [DefaultValue("Dhaka bangladesh")]
        [MaxLength(100)]
        public string Address2 { get; set; }

        [DefaultValue("Dhaka")]
        [Required]
        [MaxLength(15)]
        public string City { get; set; }

        [DefaultValue("Dhaka")]
        [Required]
        [MaxLength(15)]
        public string State { get; set; }

        [DefaultValue("Bangladesh")]
        [Required]
        [MaxLength(100)]
        public string Country { get; set; }

        [DefaultValue(1229)]
        [Required]
        [MaxLength(10)]
        public string PostCode { get; set; }

        [DefaultValue("+880152455")]
        [Required]
        [MaxLength(15)]
        public string Phone { get; set; }

        [DefaultValue("+6")]
        [Required]
        public int Timezone { get; set; }

        [DefaultValue("bd")]
        [Required]
        [MaxLength(20)]
        public string TimeZoneValue { get; set; }

        [DefaultValue("logon.png")]
        [Required]
        [MaxLength(191)]
        public string Logo { get; set; }

        [DefaultValue("+99845")]
        [Required]
        [MaxLength(15)]
        public string Fax { get; set; }

        [DefaultValue("5444654")]
        [Required]
        [MaxLength(40)]
        public string RegistrationNo { get; set; }

        [DefaultValue("465456")]
        [Required]
        [MaxLength(40)]
        public string TaxNo { get; set; }

        [DefaultValue(1)]
        [Required]
        public sbyte UniqueColumnName { get; set; }

        [DefaultValue("mahmud@softrobotics.bd")]
        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }

        [DefaultValue("secret")]
        [Required]
        [MinLength(6)]
        [MaxLength(191)]
        public string Password { get; set; }

        [DefaultValue("mahmud")]
        public string Cname { get; set; }
    }
}

