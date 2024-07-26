namespace PayAll.Response.Common
{
    public class ErrorResponse
    {
        public string code { get; set; }
        public string message { get; set; }
        public string trace_id { get; set; }
        public Details details { get; set; }
    }
    public class Details
    {
        public string additionalProp { get; set; }
    }

}