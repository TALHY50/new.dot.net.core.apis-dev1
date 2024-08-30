using System.ComponentModel;

namespace ACL.Business.Contracts.Responses
{
    public class BaseResponse
    {
        public int StatusCode { get; set; }
        [DefaultValue("Data Not Found")]
        public virtual string? Message { get; set; } = "Data Not Found";
        [DefaultValue(null)]
        public virtual object? Data { get; set; }
        public virtual DateTime? Timestamp { get; set; } = DateTime.Now;

    }
}
