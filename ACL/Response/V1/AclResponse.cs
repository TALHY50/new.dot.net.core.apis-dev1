using System.ComponentModel;
using System.Net;
using ACL.Database.Models;

namespace ACL.Response.V1
{
    public class AclResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        [DefaultValue("Data Not Found")]
        public string Message { get; set; } = "Data Not Found";
        [DefaultValue(null)]
        public object Data { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;

    }
}
