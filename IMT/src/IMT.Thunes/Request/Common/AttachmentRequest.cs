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
        public string Name { get; set; }
        public string Type { get; set; }
        public IFormFile File { get; set; }
        public int TransactionId { get; set; }
    }
}
