using System.Net;
using ACL.Database.Models;

namespace ACL.Response.V1
{
    public class AclResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; } = "Data Not Found";
        public object Data { get; set; }
        public DateTime Timestamp { get; set; }

    }
}
