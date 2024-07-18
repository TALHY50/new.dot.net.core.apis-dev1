using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMT.Thunes.Request.Common
{
    public class AttachmentRequest
    {
        public string name { get; set; }
        public string type { get; set; }
        public IFormFile file { get; set; }
        public int transaction_id { get; set; }
    }
}
