namespace IMT.Thunes.Response.Common
{
    public class ErrorResponse
    {
        public string ErrorCode { get; set; }
        public string ErrorDescription { get; set; }
    }
    public class ErrorsResponse
    {
        public string code { get; set; }
        public string message { get; set; }
    }
}