namespace SharedBusiness.Main.Common.Domain.Entities;

public partial class CustomerBank
{
    public uint Id { get; set; }

    public uint? CustomerId { get; set; }

    public uint? CountryId { get; set; }

    public uint? CityId { get; set; }

    public uint? BankId { get; set; }

    public string? AccountTitle { get; set; }

    public string? AccountNo { get; set; }

    public string? BranchIban { get; set; }

    public uint? CreatedById { get; set; }

    public uint? UpdatedById { get; set; }

    /// <summary>
    /// 1=active, 0=inactive, 2= soft-deleted
    /// </summary>
    public byte? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
