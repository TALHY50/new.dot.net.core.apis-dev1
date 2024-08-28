namespace IMT.App.Domain.Entities;

public partial class CustomerBank
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public int? CountryId { get; set; }

    public int? CityId { get; set; }

    public int? BankId { get; set; }

    public string? AccountTitle { get; set; }

    public string? AccountNo { get; set; }

    public string? BranchIban { get; set; }

    public int? CreatedById { get; set; }

    public int? UpdatedById { get; set; }

    /// <summary>
    /// 1=active, 0=inactive, 2= soft-deleted
    /// </summary>
    public sbyte? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
