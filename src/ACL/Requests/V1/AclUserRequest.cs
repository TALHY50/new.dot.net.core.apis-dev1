using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace ACL.Requests.V1
{
    public class AclUserRequest
    {
        [Required]
        [StringLength(100)]
        public string first_name { get; set; }

        [Required]
        [StringLength(100)]
        public string last_name { get; set; }

        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        [StringLength(255)]
        public string avatar { get; set; }

        [Required]
        //[MaxLength(255)]
        //[MinLength(6)]
        public string password { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime dob { get; set; }

        [Required]
        [Range(1, 4)]
        public sbyte gender { get; set; }

        [MaxLength(255)]
        public string address { get; set; }

        //[MaxLength(100)]
        public string city { get; set; }

        public uint country { get; set; }

        //[MaxLength(20)]
        public string phone { get; set; }

        //[MaxLength(20)]
        public string username { get; set; }

        //[MaxLength(255)]
        public string img_path { get; set; }

        [Required]
        //[MaxLength(4)]
        //[MinLength(0)]
        public sbyte status { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Array must contain at least one element.")]
        public ulong[] usergroup { get; set; }

    }

}
