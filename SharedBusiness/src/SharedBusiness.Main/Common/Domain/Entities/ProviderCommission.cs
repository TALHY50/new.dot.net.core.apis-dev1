namespace SharedBusiness.Main.Common.Domain.Entities;

public partial class ProviderCommission
{
    public uint Id { get; set; }

    public uint? ProviderId { get; set; }

    public uint? FromCurrencyId { get; set; }

    public uint? ToCurrencyId { get; set; }

    public decimal? SenderCommissionPercentage { get; set; }

    public decimal? SenderCommissionFixed { get; set; }

    public decimal? ReceiverCommissionPercentage { get; set; }

    public decimal? ReceiverCommissionFixed { get; set; }

    public uint? UpdatedById { get; set; }

    public uint? CreatedById { get; set; }

    /// <summary>
    /// 1=active, 0=inactive, 2=soft-deleted
    /// </summary>
    public byte? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
