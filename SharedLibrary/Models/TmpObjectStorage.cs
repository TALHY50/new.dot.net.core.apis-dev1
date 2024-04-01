namespace SharedLibrary.Models;

public partial class TmpObjectStorage
{
    public int Id { get; set; }

    public string OrderId { get; set; } = null!;

    public string? Pos { get; set; }

    public string? Request { get; set; }

    public string? Currency { get; set; }

    public string? TmpPaymentRecord { get; set; }

    public string? Merchant { get; set; }

    public string? MerchantSettings { get; set; }

    public string? PfRecords { get; set; }

    public string? DplObj { get; set; }

    public string? DplSettingsObj { get; set; }

    public string? MerchantCommission { get; set; }

    public string? MerchantPosCommission { get; set; }

    public string? PosInstallment { get; set; }

    public string? CampaignPosInstallment { get; set; }

    public string? Settlement { get; set; }

    public string? SaleCurrencyConversion { get; set; }

    public sbyte Status { get; set; }

    public DateTime? CreatedAt { get; set; }
}
