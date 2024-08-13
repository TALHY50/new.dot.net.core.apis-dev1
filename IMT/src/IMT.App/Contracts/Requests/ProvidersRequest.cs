namespace IMT.App.Contracts.Requests
{
    public class ProvidersRequest
    {
        public ulong id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string base_url { get; set; }
        public string api_key { get; set; }
        public string api_secret { get; set; }
    }
}
