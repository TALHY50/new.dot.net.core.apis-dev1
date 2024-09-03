using Ardalis.SharedKernel;

namespace SharedBusiness.Main.Common.Domain.Entities;

/// <summary>
/// Type : Master, fund deposited for an institution like Sipay in a provider account (Thunes)
/// </summary>
public partial class InstitutionFund : EntityBase<uint>, IAggregateRoot
{
    public uint InstitutionId { get; set; }

    public uint ProviderId { get; set; }

    public uint FundCountryId { get; set; }

    public uint FundCurrencyId { get; set; }

    /// <summary>
    /// Account number for the wallet
    /// </summary>
    public string AccountNumber { get; set; } = null!;

    /// <summary>
    /// Starting amount in the wallet
    /// </summary>
    public decimal StartingAmount { get; set; }

    /// <summary>
    /// Current amount in the wallet
    /// </summary>
    public decimal CurrentAmount { get; set; }

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
