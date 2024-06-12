
using System.ComponentModel.DataAnnotations;

namespace IMT.PayAll.Request.Common
{
    public class Amount
    {
        [Required]
        [MinLength(3)]
        [MaxLength(3)]
        public string currency { get; set; }
        [Required]
        public int value { get; set; }
    }
}
