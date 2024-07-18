namespace Thunes.Request.ConfirmTrasaction
{
    public class ConfirmTrasactionDTO
    {
        public string InvoiceId { get; set; }
        public int RemoteTrasactionId { get; set; }
        public int ProviderId { get; set; }
        public sbyte Type { get; set; }
    }
}
