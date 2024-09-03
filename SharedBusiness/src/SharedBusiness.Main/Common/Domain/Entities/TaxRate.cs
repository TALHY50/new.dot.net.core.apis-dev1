using Ardalis.SharedKernel;

namespace SharedBusiness.Main.Common.Domain.Entities;

/// <summary>
/// Type : Master, government tax rates based on countries for each transaction
/// </summary>
public partial class TaxRate : EntityBase<uint>, IAggregateRoot
{
    /// <summary>
    /// 1 = Regular, 2 = Corridor tax, 3 = Country tax
    /// </summary>
    public byte TaxType { get; set; }

    public uint? CorridorId { get; set; }

    public uint? CountryId { get; set; }

    public uint? TaxCurrencyId { get; set; }

    public decimal TaxPercentage { get; set; }

    public decimal TaxFixed { get; set; }

    public uint? CompanyId { get; set; }

    /// <summary>
    /// 0=inactive, 1=active, 2=pending, 3=rejected 
    /// </summary>
    public byte Status { get; set; }

    public uint? CreatedById { get; set; }

    public uint? UpdatedById { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
