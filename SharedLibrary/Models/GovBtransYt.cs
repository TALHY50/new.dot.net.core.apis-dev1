using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class GovBtransYt
{
    public int Id { get; set; }

    /// <summary>
    /// Unique Batch Number yyyy-mm-dd-serial
    /// </summary>
    public string? Batch { get; set; }

    public int? MerchantId { get; set; }

    /// <summary>
    /// unique id for every record 
    /// </summary>
    public string RecordUniqueId { get; set; } = null!;

    /// <summary>
    /// ex: 00004
    /// </summary>
    public string? OperationType { get; set; }

    /// <summary>
    /// 	E for first send, D for edit, S for delete, İ for Refund
    /// </summary>
    public string? RecordType { get; set; }

    /// <summary>
    /// 1 =&gt; withdraw,
    /// 2 =&gt; b2b,
    /// 3=&gt; b2c bank,
    /// 4 =&gt; b2c wallet
    /// </summary>
    public bool? TransactionType { get; set; }

    /// <summary>
    /// lref for btrans
    /// </summary>
    public string? TransactionId { get; set; }

    /// <summary>
    /// vkn of brand
    /// </summary>
    public string? SenderBrandVkn { get; set; }

    /// <summary>
    /// 1 for tckn
    /// </summary>
    public bool? SenderIdType { get; set; }

    /// <summary>
    /// E for Yes, H for No
    /// </summary>
    public string? IsClientSender { get; set; }

    /// <summary>
    /// full company name of brand
    /// </summary>
    public string? SenderBrandFullCompanyName { get; set; }

    /// <summary>
    /// VKN / Tax Number of Merchant
    /// </summary>
    public string? SenderVkn { get; set; }

    /// <summary>
    /// Full company name of Merchant
    /// </summary>
    public string? SenderCompanyName { get; set; }

    /// <summary>
    /// name of merchant
    /// </summary>
    public string? SenderName { get; set; }

    /// <summary>
    /// surname of merchant
    /// </summary>
    public string? SenderSurname { get; set; }

    /// <summary>
    /// TCKN of Merchant
    /// </summary>
    public string? SenderTckn { get; set; }

    /// <summary>
    /// ex: TR
    /// </summary>
    public string? SenderCountryCode { get; set; }

    /// <summary>
    /// Address 1 of Merchant
    /// </summary>
    public string? SenderAddress { get; set; }

    /// <summary>
    /// city of merchant
    /// </summary>
    public string? SenderCity { get; set; }

    /// <summary>
    /// district of sender merchant
    /// </summary>
    public string? SenderDistrict { get; set; }

    /// <summary>
    /// Zip Code of Merchant
    /// </summary>
    public string? SenderZipCode { get; set; }

    /// <summary>
    /// License Tag of Merchant 
    /// </summary>
    public string? SenderLicenseTag { get; set; }

    /// <summary>
    /// Authorized Person Phone Number of Merchant
    /// &quot;* Authorized Person E-Mail of Merchant
    /// </summary>
    public string? SenderAuthorizedPhone { get; set; }

    /// <summary>
    /// Authorized Person Email of Merchant
    /// </summary>
    public string? SenderAuthorizedEmail { get; set; }

    public string? SenderCreditCardNo { get; set; }

    public string? SenderDebitCardNo { get; set; }

    /// <summary>
    /// VKN / Tax Number of Merchant
    /// </summary>
    public string? ReceiverVkn { get; set; }

    /// <summary>
    /// Full company name of Merchant
    /// </summary>
    public string? ReceiverCompanyName { get; set; }

    /// <summary>
    /// E for Yes, H for No
    /// </summary>
    public string? IsClientReceiver { get; set; }

    /// <summary>
    /// 1 for tckn
    /// </summary>
    public bool? ReceiverIdType { get; set; }

    /// <summary>
    /// name of merchant
    /// </summary>
    public string? ReceiverName { get; set; }

    /// <summary>
    /// surname of merchant
    /// </summary>
    public string? ReceiverSurname { get; set; }

    /// <summary>
    /// TCKN of Merchant
    /// </summary>
    public string? ReceiverTckn { get; set; }

    /// <summary>
    /// ex: TR
    /// </summary>
    public string? ReceiverCountryCode { get; set; }

    /// <summary>
    /// Address 1 of Merchant
    /// </summary>
    public string? ReceiverAddress { get; set; }

    /// <summary>
    /// city of merchant
    /// </summary>
    public string? ReceiverCity { get; set; }

    /// <summary>
    /// district of receiver merchant
    /// </summary>
    public string? ReceiverDistrict { get; set; }

    /// <summary>
    /// Zip Code of Merchant
    /// </summary>
    public string? ReceiverZipCode { get; set; }

    /// <summary>
    /// License Tag of Merchant 
    /// </summary>
    public string? ReceiverLicenseTag { get; set; }

    /// <summary>
    /// Authorized Person Phone Number of Merchant
    /// </summary>
    public string? ReceiverAuthorizedPhone { get; set; }

    /// <summary>
    /// Authorized Person Phone Number of Merchant
    /// &quot;* Authorized Person E-Mail of Merchant
    /// </summary>
    public string? ReceiverAuthorizedEmail { get; set; }

    /// <summary>
    /// bank code of receiver
    /// </summary>
    public string? ReceiverBankCode { get; set; }

    /// <summary>
    /// branch code of receiver
    /// </summary>
    public string? ReceiverBankBranchCode { get; set; }

    /// <summary>
    /// Iban of receiver
    /// </summary>
    public string? ReceiverBankAccountIban { get; set; }

    /// <summary>
    /// bank account of receiver
    /// </summary>
    public string? ReceiverBankAccount { get; set; }

    /// <summary>
    /// bank name of receiver
    /// </summary>
    public string? ReceiverBankName { get; set; }

    /// <summary>
    /// brand vkn of receiver
    /// </summary>
    public string? ReceiverBrandVkn { get; set; }

    /// <summary>
    /// brand full company name of receiver
    /// </summary>
    public string? ReceiverBrandFullCompanyName { get; set; }

    /// <summary>
    /// According to ISO standards For example; TRY, USD, EUR, XAU
    /// </summary>
    public string? CurrencyCode { get; set; }

    /// <summary>
    /// Activation Date
    /// </summary>
    public DateOnly? ActivationDate { get; set; }

    /// <summary>
    /// Total Balance of merchant
    /// </summary>
    public decimal? Balance { get; set; }

    /// <summary>
    /// Sender Bank of Sipay
    /// </summary>
    public string? SenderBankName { get; set; }

    /// <summary>
    /// Sender bank code
    /// </summary>
    public string? SenderBankCode { get; set; }

    /// <summary>
    /// Sender branch code of bank
    /// </summary>
    public string? SenderBankBranchCode { get; set; }

    /// <summary>
    /// Sender Iban of merchant
    /// </summary>
    public string? SenderBankAccountIban { get; set; }

    /// <summary>
    /// Sender Merchant&apos;s IBAN No&apos; last 7 numbers
    /// </summary>
    public string? SenderBankAccount { get; set; }

    /// <summary>
    /// date of processing
    /// </summary>
    public string? ProcessDate { get; set; }

    /// <summary>
    /// time of processing
    /// </summary>
    public string? ProcessTime { get; set; }

    /// <summary>
    /// Ex: Para Çekme
    /// </summary>
    public string? TransactionableType { get; set; }

    public string? SenderEMoneyAccount { get; set; }

    public string? SenderCardNo { get; set; }

    public string? ReceiverBrandBankIban { get; set; }

    public string? ReceiverEMoneyAccount { get; set; }

    public string? ReceiverCardNo { get; set; }

    public string? ReceiverCreditCardNo { get; set; }

    public string? ReceiverDebitCardNo { get; set; }

    public string? TransactionDate { get; set; }

    public string? TransactionTime { get; set; }

    public decimal? TransactionAmount { get; set; }

    /// <summary>
    /// 1=Dues, 2=Residence Rent, 3=Education, 4=Credit Card Debt, 5= Personnel Payments, 6=Workplace Rent, 7=Other Rents, 8=e-commerce, 9=Other
    /// </summary>
    public bool? TransactionDescriptionEnum { get; set; }

    /// <summary>
    /// Transaction Channel: 1=Branch, 2=Agent, 3=ATM/Kiosk, 4-Other OHS, 5=Mobile and 6=Website
    /// </summary>
    public sbyte? TransactionChannel { get; set; }

    public string? BranchAuthorisedVkn { get; set; }

    public string? BranchAuthorisedName { get; set; }

    public string? BranchAuthorisedCity { get; set; }

    public string? ClientDescription { get; set; }

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
    /// total amount
    /// </summary>
    public decimal? NetAmount { get; set; }

    /// <summary>
    /// total commission
    /// </summary>
    public decimal? Commission { get; set; }

    /// <summary>
    /// 0 =&gt; Not Processed,1 =&gt; Pending,2 =&gt; Rejected,3 =&gt; Completed
    /// </summary>
    public sbyte Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
