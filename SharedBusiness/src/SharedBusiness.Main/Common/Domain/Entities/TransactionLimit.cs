using Ardalis.SharedKernel;


namespace SharedBusiness.Main.Common.Domain.Entities;

public partial class TransactionLimit : EntityBase<uint>, IAggregateRoot
{

    public sbyte? TransactionType { get; set; }

    public sbyte? UserCategory { get; set; }

    public int? DailyTotalNumber { get; set; }

    public decimal? DailyTotalAmount { get; set; }

    public int? MonthlyTotalNumber { get; set; }

    public decimal? MonthlyTotalAmount { get; set; }

    public uint? CurrencyId { get; set; }

    public uint? CreatedById { get; set; }

    public uint? UpdatedById { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
