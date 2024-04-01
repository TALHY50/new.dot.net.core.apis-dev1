using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class MerchantApplication
{
    public uint Id { get; set; }

    /// <summary>
    /// 1 =&apos;Corporate&apos;,2 =&apos;Individual&apos;
    /// </summary>
    public sbyte? MerchantType { get; set; }

    /// <summary>
    /// Merchant Name
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Merchant Surname
    /// </summary>
    public string? Surname { get; set; }

    /// <summary>
    /// Name of the merchant
    /// </summary>
    public string? MerchantName { get; set; }

    /// <summary>
    /// Name of the company
    /// </summary>
    public string? CompanyName { get; set; }

    /// <summary>
    /// Merchant webside url
    /// </summary>
    public string? Website { get; set; }

    /// <summary>
    /// Merchant Auth person name
    /// </summary>
    public string? AuthPersonName { get; set; }

    /// <summary>
    /// Merchant Auth Person Email
    /// </summary>
    public string? AuthPersonEmail { get; set; }

    /// <summary>
    /// Merchant Auth person phone
    /// </summary>
    public string? AuthPersonPhone { get; set; }

    /// <summary>
    /// Merchant Address
    /// </summary>
    public string? Address { get; set; }

    public string? ZipCode { get; set; }

    public string? City { get; set; }

    public string? Country { get; set; }

    public string? TaxOffice { get; set; }

    public string? TaxNumber { get; set; }

    public string? BusinessArea { get; set; }

    public string? ExpectedVolume { get; set; }

    public string? PreferredPaymentMethod { get; set; }

    public string? ContractPersonName { get; set; }

    public string? ContractPersonPhone { get; set; }

    public string? ContractPersonEmail { get; set; }

    public string? MerchantLogo { get; set; }

    /// <summary>
    /// Social media links
    /// </summary>
    public string? SocialMedia { get; set; }

    public string? Document { get; set; }

    public string? ApplicationDate { get; set; }

    public string? Reason { get; set; }

    /// <summary>
    /// Like TRY, EUR, USD, RUB. GBP, AZN
    /// </summary>
    public string? CurrencyCode { get; set; }

    /// <summary>
    /// Double/Integer
    /// </summary>
    public double? AverageMonthlyEarning { get; set; }

    /// <summary>
    /// 0=pending, 1=approved,2=reject
    /// </summary>
    public sbyte Status { get; set; }

    /// <summary>
    /// tenant app key
    /// </summary>
    public string? TenantAppId { get; set; }

    /// <summary>
    /// tenant app secret
    /// </summary>
    public string? TenantAppSecret { get; set; }

    /// <summary>
    /// tenant app url
    /// </summary>
    public string? TenantAppUrl { get; set; }

    /// <summary>
    /// email_verified = 1, email_not_verified =0
    /// </summary>
    public sbyte? IsEmailVerified { get; set; }

    /// <summary>
    /// password_exists =&gt; 1,password_not_exists =&gt; 0 
    /// </summary>
    public sbyte? IsPasswordExists { get; set; }

    /// <summary>
    /// 1 = Normal Application, 2 = OnBoarding Merchant Application, 3 = Sales Panel Application
    /// </summary>
    public sbyte? Source { get; set; }

    /// <summary>
    /// Hash Password
    /// </summary>
    public string? Password { get; set; }

    /// <summary>
    /// Merchant Application Authentication Token
    /// </summary>
    public string? AuthenticationToken { get; set; }

    /// <summary>
    /// assigned admin user id
    /// </summary>
    public int? AssignedUserId { get; set; }

    /// <summary>
    /// merchant id of tenant
    /// </summary>
    public int? TenantMerchantId { get; set; }

    /// <summary>
    /// merchant application user login failed attempts counter
    /// </summary>
    public sbyte LoginFailedAttempts { get; set; }

    /// <summary>
    /// 0 = Waiting For Documentation, 1 = Completed, 2 = waiting at operation
    /// </summary>
    public sbyte Stage { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? Mcc { get; set; }
}
