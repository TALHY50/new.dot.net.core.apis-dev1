

namespace IMT.PayAll.Response
{
    public class HttpResponseModel
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public string ReasonPhrase { get; set; }
        public string Version { get; set; }
        public Dictionary<string, string> Headers { get; set; }
        public string Content { get; set; }

    }
}
