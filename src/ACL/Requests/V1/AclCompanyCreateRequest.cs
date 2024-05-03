using System.ComponentModel.DataAnnotations;

namespace ACL.Requests.V1
{
    public class AclCompanyCreateRequest
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Cemail { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address1 { get; set; }

        [MaxLength(100)]
        public string Address2 { get; set; }

        [Required]
        [MaxLength(15)]
        public string City { get; set; }

        [Required]
        [MaxLength(15)]
        public string State { get; set; }

        [Required]
        [MaxLength(100)]
        public string Country { get; set; }

        [Required]
        [MaxLength(10)]
        public string PostCode { get; set; }

        [Required]
        [MaxLength(15)]
        public string Phone { get; set; }

        [Required]
        public int imezone { get; set; }

        [Required]
        [MaxLength(20)]
        public string TimeZoneValue { get; set; }

        [Required]
        [MaxLength(191)]
        public string Logo { get; set; }

        [Required]
        [MaxLength(15)]
        public string Fax { get; set; }

        [Required]
        [MaxLength(40)]
        public string RegistrationNo { get; set; }

        [Required]
        [MaxLength(40)]
        public string TaxNo { get; set; }

        [Required]
        public sbyte UniqueColumnName { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(191)]
        public string Password { get; set; }

        public string Cname { get; set; }
    }
}

