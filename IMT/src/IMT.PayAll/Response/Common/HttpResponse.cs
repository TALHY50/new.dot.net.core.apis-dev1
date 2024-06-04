

namespace IMT.PayAll.Response.Common
{
    public class HttpResponse<T>    
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public string ReasonPhrase { get; set; }
        public string Version { get; set; }
        public Dictionary<string, string> Headers { get; set; }
        public string? Content { get; set; }
        public T Data { get; set; }

    }
}
