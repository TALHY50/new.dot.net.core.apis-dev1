using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class GovBtransSfp
{
    public int Id { get; set; }

    /// <summary>
    /// Unique Batch Number
    /// </summary>
    public string? Batch { get; set; }

    /// <summary>
    /// Unique string every report item
    /// </summary>
    public string? Lref { get; set; }

    /// <summary>
    /// SP002 - Virtual POS, FS001 - Physical POS
    /// </summary>
    public string? OperationType { get; set; }

    /// <summary>
    /// E - Sending for the first time, D - Update, S - Delete, I - Refund of Withdraw(when we cancel it after its sent to BTrans)
    /// </summary>
    public string? RecordType { get; set; }

    /// <summary>
    /// VKN of Brand
    /// </summary>
    public string? BrandVkn { get; set; }

    /// <summary>
    /// Full Company Name of Brand
    /// </summary>
    public string? BrandFullCompanyName { get; set; }

    public string? PosBankName { get; set; }

    public string? BankCode { get; set; }

    public string? PosId { get; set; }

    public string? BankTerminalNo { get; set; }

    public string? PosAccountBankName { get; set; }

    public string? PosAccountBankCode { get; set; }

    public string? PosAccountBankIban { get; set; }

    /// <summary>
    /// VKN / Tax Number of Merchant
    /// </summary>
    public string? MerchantVkn { get; set; }

    /// <summary>
    /// TCKN of Merchant
    /// </summary>
    public string? MerchantTckn { get; set; }

    /// <summary>
    /// Full Company Name of Merchant
    /// </summary>
    public string? MerchantFullCompanyName { get; set; }

    /// <summary>
    /// USER 
    /// </summary>
    public string? MerchantAuthUserName { get; set; }

    /// <summary>
    /// AUTH USER SURNAME
    /// </summary>
    public string? MerchantAuthUserSurname { get; set; }

    /// <summary>
    /// ex: TR
    /// </summary>
    public string? MerchantCountryCode { get; set; }

    /// <summary>
    /// Address 1 of Merchant
    /// </summary>
    public string? MerchantAddress { get; set; }

    /// <summary>
    /// District of Merchant
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

    public string? MerchantCity { get; set; }

    /// <summary>
    /// Authorized Person Phone Number of Merchant
    /// </summary>
    public string? MerchantAuthorizedPhone { get; set; }

    public int? MerchantId { get; set; }

    public DateTime? SaleCreatedAt { get; set; }

    public DateTime? SaleSettlementDateMerchant { get; set; }

    /// <summary>
    /// Sale net amount
    /// </summary>
    public decimal? SaleNet { get; set; }

    public double? SaleNetTry { get; set; }

    /// <summary>
    /// Sale net amount
    /// </summary>
    public decimal? SaleGross { get; set; }

    /// <summary>
    /// ex: TRY/USD
    /// </summary>
    public string? SaleCurrencyCode { get; set; }

    /// <summary>
    /// Sale Merchant Commission
    /// </summary>
    public decimal? SaleMerchantCommission { get; set; }

    /// <summary>
    /// Description of a sale
    /// </summary>
    public string? SaleDescription { get; set; }

    /// <summary>
    /// company code ex: 048
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
    /// 0 =&gt; Not Processed , 
    /// 1 =&gt; Pending,
    /// 2 =&gt; Rejected,
    /// 3 =&gt; Completed
    /// </summary>
    public sbyte Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
