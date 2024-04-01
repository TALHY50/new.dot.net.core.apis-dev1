using SharedLibrary.Attributes;

namespace SharedLibrary.DTOs;

public class PaymentHashContent
{
    [PropertyOrder(1)]
    public string total { get; set; } = String.Empty;
    [PropertyOrder(2)]
    public string installment { get; set; } = String.Empty;
    [PropertyOrder(3)]
    public string currencyCode { get; set; } = String.Empty;
    [PropertyOrder(4)]
    public string merchantKey { get; set; } = String.Empty;
    [PropertyOrder(5)]
    public string invoiceId { get; set; } = String.Empty;
}