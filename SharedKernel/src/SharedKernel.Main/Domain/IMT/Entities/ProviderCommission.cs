namespace SharedKernel.Main.Domain.IMT.Entities;

public partial class ProviderCommission
{
    public int Id { get; set; }

    public int? ProviderId { get; set; }

    public int? FromCurrencyId { get; set; }

    public int? ToCurrencyId { get; set; }

    public decimal? SenderCommissionPercentage { get; set; }

    public decimal? SenderCommissionFixed { get; set; }

    public decimal? ReceiverCommissionPercentage { get; set; }

    public decimal? ReceiverCommissionFixed { get; set; }

    public int? UpdatedById { get; set; }

    public int? CreatedById { get; set; }

    public sbyte? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
