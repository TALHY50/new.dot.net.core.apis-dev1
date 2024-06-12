using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMT.PayAll.Model;

namespace IMT.PayAll.Response.Common
{
    public class SourceAmount
    {
        [Required]
        [MaxLength(3)]
        [MinLength(3)]
        public string currency { get; set; }
        [Required]
        public int value { get; set; }
    }
}
