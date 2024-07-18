namespace SharedKernel.Domain.IMT;

public partial class ImtTransactionLimit
{
    public int Id { get; set; }

    public sbyte? TransactionType { get; set; }

    public sbyte? UserCategory { get; set; }

    public int? DailyTotalNumber { get; set; }

    public decimal? DailyTotalAmount { get; set; }

    public int? MonthlyTotalNumber { get; set; }

    public decimal? MonthlyTotalAmount { get; set; }

    public int? CurrencyId { get; set; }

    public int? CreatedById { get; set; }

    public int? UpdatedById { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
