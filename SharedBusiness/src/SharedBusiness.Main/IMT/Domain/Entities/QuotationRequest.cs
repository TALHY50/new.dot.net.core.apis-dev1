namespace SharedBusiness.Main.IMT.Domain.Entities;

public partial class QuotationRequest
{
    public uint Id { get; set; }

    public string? Request { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
