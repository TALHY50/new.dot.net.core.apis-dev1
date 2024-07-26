namespace Thunes.Response.Transfer.Quotation
{
    public class BaseCreateQuatationResponse
    {
        public int StatusCode { get; set; }
        public string ReasonPhrase { get; set; }
        public CreateContentQuotationResponse Content { get; set; }
        public string Version { get; set; }

    }
}