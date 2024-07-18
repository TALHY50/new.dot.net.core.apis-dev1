using Microsoft.AspNetCore.Http;

namespace Thunes.Request.Common
{
    public class AttachmentRequest
    {
        public string name { get; set; }
        public string type { get; set; }
        public IFormFile file { get; set; }
        public int transaction_id { get; set; }
    }
}
