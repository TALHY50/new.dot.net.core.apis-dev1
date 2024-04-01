using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class WalletGateSetting
{
    public int Id { get; set; }

    public string? CurrencyCode { get; set; }

    public string? SenderAccountNumber { get; set; }

    public string? SenderWalletNumber { get; set; }

    public string? TenantCode { get; set; }

    public string? SenderIban { get; set; }

    public string? SenderBankCode { get; set; }

    public string? SenderBankName { get; set; }

    public string? ReceiverIban { get; set; }

    public string? ReceiverBankCode { get; set; }

    public string? ReceiverBankName { get; set; }

    public string? RegexDefinitionResultData { get; set; }

    public string? NationalIdOrTaxNo { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
