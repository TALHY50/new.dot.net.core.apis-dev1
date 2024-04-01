using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class GovBtransEphpycni
{
    public int Id { get; set; }

    /// <summary>
    /// E for first send, D for update, S for delete, İ for refund
    /// </summary>
    public string? RecordType { get; set; }

    /// <summary>
    /// unique id for every record	
    /// </summary>
    public string? RecordUniqueId { get; set; }

    /// <summary>
    /// Transaction Id
    /// </summary>
    public string? TransactionId { get; set; }

    /// <summary>
    /// EP002, OK003 , KK101
    /// </summary>
    public string? OperationType { get; set; }

    /// <summary>
    /// E/H
    /// </summary>
    public string? IsClientSender { get; set; }

    public string? SenderBrandVkn { get; set; }

    public string? SenderBrandFullCompanyName { get; set; }

    public string? SenderName { get; set; }

    public string? SenderSurname { get; set; }

    /// <summary>
    /// 1=T.C. ID Card,2=Old type T.C. ID Card, 3=Driver Licence 4=Passport 5=Other
    /// </summary>
    public bool? SenderIdType { get; set; }

    public string? SenderTckn { get; set; }

    /// <summary>
    /// (ISO STANDARTS FOR EXAMPLE; TR, US, FR, NL)
    /// </summary>
    public string? MerchantsCountryCode { get; set; }

    public string? MerchantsAddress { get; set; }

    public string? MerchantsDistrict { get; set; }

    public string? MerchantsZipCode { get; set; }

    public string? MerchantsLicenseTag { get; set; }

    public string? MerchantsCity { get; set; }

    public string? MerchantsAuthorizedPhone { get; set; }

    public string? MerhcantsAuthorizedEmail { get; set; }

    public int? MerchantId { get; set; }

    public string? MerchantsCurrency { get; set; }

    public bool? AccountType { get; set; }

    public string? ReceiverName { get; set; }

    public string? ReceiverSurname { get; set; }

    /// <summary>
    /// 1= Prepaid Card No, 2= Additional Card 3= Phone No, 4= E-mail Adress, 5=Merchant/User Id, 6=Credit Card No, 7=TCKN, 8=Agent of PF, 9=e-Money account, 10=Payment account
    /// </summary>
    public bool? ReceiverIdType { get; set; }

    public string? ReceiverTckn { get; set; }

    public string? ProcessDate { get; set; }

    /// <summary>
    /// 1=bank branch, 2= agent of pf, 3=ATM/Kiosk, 4-Other PF company, 5=Mobile App ,6=Web Site
    /// </summary>
    public bool? TransactionChannel { get; set; }

    public string? ReceiverBankName { get; set; }

    public decimal? NetAmountTry { get; set; }

    public decimal? NetAmount { get; set; }

    /// <summary>
    /// TRY, USD, EUR etc
    /// </summary>
    public string? CurrencyCode { get; set; }

    public decimal? Commission { get; set; }

    public string? ClientDescription { get; set; }

    public string? TransactionableType { get; set; }

    /// <summary>
    /// company code ex: 048 for sipay
    /// </summary>
    public string? CompanyCode { get; set; }

    /// <summary>
    /// 1=&gt;our system data, 2=&gt; wallet gate data
    /// </summary>
    public bool? Source { get; set; }

    /// <summary>
    /// datetime of transaction
    /// </summary>
    public DateTime? TransactionDateTime { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// 0 =&gt; Not Processed,1 =&gt; Pending,2 =&gt; Rejected,3 =&gt; Completed
    /// </summary>
    public sbyte Status { get; set; }

    /// <summary>
    /// Unique Batch Number
    /// </summary>
    public string? Batch { get; set; }
}
