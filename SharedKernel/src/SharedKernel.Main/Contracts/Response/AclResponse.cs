using System.ComponentModel;

namespace SharedKernel.Main.Contracts.Response
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
