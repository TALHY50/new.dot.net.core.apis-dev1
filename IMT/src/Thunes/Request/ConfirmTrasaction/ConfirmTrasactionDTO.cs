namespace Thunes.Request.ConfirmTrasaction
{
    public class ConfirmTrasactionDTO
    {
        public string InvoiceId { get; set; }
        public uint RemoteTrasactionId { get; set; }
        public uint ProviderId { get; set; }
        public sbyte Type { get; set; }
    }
}
