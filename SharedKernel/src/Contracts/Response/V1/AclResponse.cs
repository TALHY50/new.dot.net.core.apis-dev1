using System.ComponentModel;

namespace SharedKernel.Contracts.Response.V1
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
