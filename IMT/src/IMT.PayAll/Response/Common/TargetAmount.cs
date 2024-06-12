
using System.ComponentModel.DataAnnotations;
using IMT.PayAll.Model;


namespace IMT.PayAll.Response.Common
{
    public class TargetAmount
    {
        [Required]
        [MaxLength(3)]
        [MinLength(3)]
        public string currency { get; set; }
        [Required]
        public int value { get; set; }
    }
}
