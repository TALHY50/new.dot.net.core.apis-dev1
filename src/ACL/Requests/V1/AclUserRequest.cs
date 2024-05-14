using ACL.Database.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace ACL.Requests.V1
{
    public class AclUserRequest
    {
        [DefaultValue("Mahmud")]
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [DefaultValue("Sheikh")]
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [DefaultValue("mahmud@srbl.com")]
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [DefaultValue("Should be image as base 64")]
        [Required]
        [StringLength(255)]
        public string Avatar { get; set; }

        [DefaultValue("en-US")]
        [Required]
        [StringLength(10)]
        public string Language { get; set; }

        [DefaultValue("Srbl@123.")]
        [Required]
        //[MaxLength(255)]
        //[MinLength(6)]
        public string Password { get; set; }

        [DefaultValue("2024-04-22")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DOB { get; set; }

        [DefaultValue("1")]
        [Required]
        [Range(1, 4)]
        public sbyte Gender { get; set; }

        [DefaultValue("Pantho path Dhaka")]
        [MaxLength(255)]
        public string Address { get; set; }

        [DefaultValue("Dhaka")]
        //[MaxLength(100)]
        public string City { get; set; }

        [DefaultValue(1)]
        public uint Country { get; set; }

        [DefaultValue("+88014314xxxxx")]
        //[MaxLength(20)]
        public string Phone { get; set; }

        [DefaultValue("mahmud")]
        //[MaxLength(20)]
        public string UserName { get; set; }

        [DefaultValue("Should be base 64")]
        //[MaxLength(255)]
        public string ImgPath { get; set; }

        [DefaultValue("1")]
        [Required]
        //[MaxLength(4)]
        //[MinLength(0)]
        public sbyte Status { get; set; }

        [DefaultValue(new ulong[] { 1, 2 })]
        [Required]
        [MinLength(1, ErrorMessage = "Array must contain at least one element.")]
        public ulong[] UserGroup { get; set; }

        [Required]
        public IList<Claim>? Claims { get; set; }
        [Required]
        [DefaultValue("QVQhNmhjVBaFlKvwy+qec20itUl8kmNFgwlKVard2KDfPOmkkD3voz9xKVs+30gFKZYiVcGrRLRvJLRRklzO9g==")]
        [MaxLength(255)]
        public string? Salt { get; set; }

    }

}