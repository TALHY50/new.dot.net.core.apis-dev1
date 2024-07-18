namespace Thunes.Response.Transfer.Transaction
{
    public class TransactionAttachmentResponse
    {
        public int id { get; set; }
        public string content_type { get; set; }
        public string name { get; set; }
        public int transaction_id { get; set; }
        public string type { get; set; }
    }
}
