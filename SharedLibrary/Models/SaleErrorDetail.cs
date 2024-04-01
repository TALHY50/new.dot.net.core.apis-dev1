using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class SaleErrorDetail
{
    public int Id { get; set; }

    public int SaleId { get; set; }

    public string? OrderId { get; set; }

    public int MerchantId { get; set; }

    public string? Provider { get; set; }

    public int BankId { get; set; }

    public string? BankName { get; set; }

    public string? OriginalBankErrorCode { get; set; }

    public string? OriginalBankErrorDescription { get; set; }

    public string? BrandErrorCode { get; set; }

    public string? BrandErrorMessage { get; set; }

    public string? CurrencyCode { get; set; }

    /// <summary>
    /// 1=auth , 2=PreAuth
    /// </summary>
    public sbyte? TransactionType { get; set; }

    public string? MaskedCard { get; set; }

    /// <summary>
    /// mdStatus from bank response ranges from 0-9 0: Card verification failed, do not proceed 1: Verification successful, you can continue with the transaction 2: Card holder or bank is not registered in the system 3: The bank of the card is not registered in the system 4: Verification attempt, cardholder has chosen to register with the system later 5: Unable to verify 6: 3-D Secure error 7: System error 8: Unknown card no 9: Member Merchant not registered to 3D-Secure system (merchant or terminal number is not registered on the back as 3d)
    /// </summary>
    public string? MdStatus { get; set; }

    public string? ProcReturnCode { get; set; }

    public string? MdErrorMessage { get; set; }

    public string? AuthCode { get; set; }

    public string? RemoteOrderId { get; set; }

    public string? HostReferenceId { get; set; }

    public string? HostMessage { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
