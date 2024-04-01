using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class GovBtransEpkbb
{
    public int Id { get; set; }

    /// <summary>
    /// Unique Batch Number
    /// </summary>
    public string? Batch { get; set; }

    public int? MerchantId { get; set; }

    /// <summary>
    /// unique id for every record 
    /// </summary>
    public string RecordUniqueId { get; set; } = null!;

    /// <summary>
    /// E for first send, D for edit, S for delete, İ for Refund
    /// </summary>
    public string? RecordType { get; set; }

    /// <summary>
    /// 1 =&gt; name,
    /// 2 =&gt; balance
    /// </summary>
    public bool? TransactionType { get; set; }

    /// <summary>
    /// lref for btrans
    /// </summary>
    public string? TransactionId { get; set; }

    /// <summary>
    /// ex: EP002
    /// </summary>
    public string? OperationType { get; set; }

    /// <summary>
    /// VKN / Tax Number of Merchant
    /// </summary>
    public string? MerchantVkn { get; set; }

    /// <summary>
    /// Full company name of Merchant
    /// </summary>
    public string? MerchantCompanyName { get; set; }

    /// <summary>
    /// name of merchant
    /// </summary>
    public string? UsersName { get; set; }

    /// <summary>
    /// surname of merchant
    /// </summary>
    public string? UsersSurname { get; set; }

    /// <summary>
    /// TCKN of Merchant
    /// </summary>
    public string? MerchantTckn { get; set; }

    /// <summary>
    /// ex: TR
    /// </summary>
    public string? MerchantCountryCode { get; set; }

    /// <summary>
    /// Address 1 of Merchant
    /// </summary>
    public string? MerchantAddress { get; set; }

    /// <summary>
    /// city of merchant
    /// </summary>
    public string? MerchantCity { get; set; }

    /// <summary>
    /// district of merchant
    /// </summary>
    public string? MerchantDistrict { get; set; }

    /// <summary>
    /// Zip Code of Merchant
    /// </summary>
    public string? MerchantZipCode { get; set; }

    /// <summary>
    /// License Tag of Merchant 
    /// </summary>
    public string? MerchantLicenseTag { get; set; }

    /// <summary>
    /// Authorized Person Phone Number of Merchant
    /// &quot;* Authorized Person E-Mail of Merchant
    /// </summary>
    public string? MerchantAuthorizedPhone { get; set; }

    /// <summary>
    /// Authorized Person Phone Number of Merchant
    /// &quot;* Authorized Person E-Mail of Merchant
    /// </summary>
    public string? MerchantAuthorizedEmail { get; set; }

    /// <summary>
    /// According to ISO standards For example; TRY, USD, EUR, XAU
    /// </summary>
    public string? MerchantCurrencyCode { get; set; }

    /// <summary>
    /// Activation Date
    /// </summary>
    public string? MerchantActivationDate { get; set; }

    /// <summary>
    /// 1=TCKN ,2=OLD TCKN,3=Driver license,4=Passsport,5=Other&quot;
    /// </summary>
    public bool? MerchantIdType { get; set; }

    /// <summary>
    /// 1= When a merchant first activated, 
    /// 2= Update on balance or address of merchant, 
    /// 3= Cancel, 
    /// 4=Closed
    /// </summary>
    public bool? MerchantStatus { get; set; }

    public string? MerchantCloseDate { get; set; }

    /// <summary>
    /// 1= New, 2= Update, 3= Cancel,4=Close
    /// </summary>
    public bool? CardStatus { get; set; }

    /// <summary>
    /// YYYYMMDD
    /// </summary>
    public string? CardActivationDate { get; set; }

    /// <summary>
    /// YYYYMMDD
    /// </summary>
    public string? CardCloseDate { get; set; }

    /// <summary>
    /// 19 digits card number
    /// </summary>
    public string? CardNumber { get; set; }

    /// <summary>
    /// 1= Prepaid Card Number, 2= Additional Card, 3= Phone Number, 4= Email Address, 5=Customer Number/Merchant Number 6=TCKN,7=e-money,8=Agent of PF, 9=Payment Account
    /// </summary>
    public bool? AccountType { get; set; }

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

    /// <summary>
    /// Total Balance of merchant
    /// </summary>
    public decimal? MerchantBalance { get; set; }

    /// <summary>
    /// 0 =&gt; Not Processed,1 =&gt; Pending,2 =&gt; Rejected,3 =&gt; Completed
    /// </summary>
    public sbyte Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
