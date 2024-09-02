using Ardalis.SharedKernel;

namespace SharedBusiness.Main.Common.Domain.Entities;

public partial class City : EntityBase<uint>, IAggregateRoot
{
    public string? Name { get; set; }

    public uint? CountryId { get; set; }

    public uint? CreatedById { get; set; }

    public uint? UpdatedById { get; set; }

    /// <summary>
    /// 1=active, 0=inactive, 2=soft-deleted
    /// </summary>
    public byte? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
