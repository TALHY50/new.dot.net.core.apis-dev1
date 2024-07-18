using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMT.PayAll.Request.Common
{
    public class SupportingDocument
    {
        [Required]
        public string document_id { get; set; }
    }

}
