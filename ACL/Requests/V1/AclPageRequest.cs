
using System.ComponentModel.DataAnnotations;

namespace ACL.Requests.V1
{
    public class AclPageRequest
    {

        [Required]
        [Range(1, ulong.MaxValue)]
        public ulong module_id { get; set; }

        [Required]
        [Range(1, ulong.MaxValue)]
        public ulong sub_module_id { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string method_name { get; set; } = null!;

        /// <summary>
        /// 1=Post, 2=Get, 3=Put, 4=Delete
        /// </summary>

        [Required]
        [Range(1, 4)]
        public int method_type { get; set; }
    }
}
