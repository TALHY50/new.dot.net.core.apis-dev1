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
        public string first_name { get; set; }

        [DefaultValue("Sheikh")]
        [Required]
        [StringLength(100)]
        public string last_name { get; set; }

        [DefaultValue("mahmud@srbl.com")]
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string email { get; set; }

        [DefaultValue("Should be image as base 64")]
        [Required]
        [StringLength(255)]
        public string avatar { get; set; }

        [DefaultValue("Srbl@123.")]
        [Required]
        //[MaxLength(255)]
        //[MinLength(6)]
        public string password { get; set; }

        [DefaultValue("2024-04-22")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime dob { get; set; }

        [DefaultValue("1")]
        [Required]
        [Range(1, 4)]
        public sbyte gender { get; set; }

        [DefaultValue("Pantho path Dhaka")]
        [MaxLength(255)]
        public string address { get; set; }

        [DefaultValue("Dhaka")]
        //[MaxLength(100)]
        public string city { get; set; }

        [DefaultValue(1)]
        public uint country { get; set; }

        [DefaultValue("+88014314xxxxx")]
        //[MaxLength(20)]
        public string phone { get; set; }

        [DefaultValue("mahmud")]
        //[MaxLength(20)]
        public string username { get; set; }

        [DefaultValue("Should be base 64")]
        //[MaxLength(255)]
        public string img_path { get; set; }

        [DefaultValue("1")]
        [Required]
        //[MaxLength(4)]
        //[MinLength(0)]
        public sbyte status { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Array must contain at least one element.")]
        public ulong[] usergroup { get; set; }

    }

}
