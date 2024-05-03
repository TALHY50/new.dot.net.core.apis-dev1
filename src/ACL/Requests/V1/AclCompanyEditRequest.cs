using System.ComponentModel.DataAnnotations;

namespace ACL.Requests.V1
{
    public class AclCompanyEditRequest
    {
        [Required]
        [MaxLength(100)]
        public string Cname { get; set; }

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
        public int Timezone { get; set; }

        [Required]
        public int UniqueColumnName { get; set; }

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
        [MaxLength(20)]
        public string TimezoneValue { get; set; }

        [Required]
        public sbyte Status { get; set; }

        public string Name { get; set; }
        //public string prop { get; set; }
    }
}
