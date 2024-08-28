namespace IMT.App.Domain.Entities
{
    public partial class QuotationRequest
    {
        public uint Id { get; set; } // `uint` for unsigned int
        public string Request { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
