
using System.ComponentModel.DataAnnotations;

namespace IMT.PayAll.Request.Common
{
    public class Amount
    {
        [Required]
        public string currency { get; set; }
        [Required]
        public int value { get; set; }
    }
}
