using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMT.PayAll.Response.Common
{
    public class TargetAmount
    {
        [Required]
        public string currency { get; set; }
        [Required]
        public int value { get; set; }
    }
}
