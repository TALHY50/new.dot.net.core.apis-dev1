using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class MerchantIk
{
    public int Id { get; set; }

    /// <summary>
    /// Merchant ID
    /// </summary>
    public uint PspMerchantId { get; set; }

    /// <summary>
    /// Global Merchant Id from api
    /// </summary>
    public uint GlobalMerchantId { get; set; }

    /// <summary>
    /// merchant table primary key
    /// </summary>
    public uint MerchantId { get; set; }

    /// <summary>
    /// Merchant VKN info
    /// </summary>
    public string TaxNo { get; set; } = null!;

    /// <summary>
    /// Full Company Name
    /// </summary>
    public string TradeName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string District { get; set; } = null!;

    /// <summary>
    /// area of district
    /// </summary>
    public string? Neighberhood { get; set; }

    /// <summary>
    /// license plate code
    /// </summary>
    public ushort LicenseTag { get; set; }

    /// <summary>
    /// Iso Country Code
    /// </summary>
    public string CountryCode { get; set; } = null!;

    /// <summary>
    /// Workplace Category Code
    /// </summary>
    public ushort Mcc { get; set; }

    /// <summary>
    /// Authorized Person Name
    /// </summary>
    public string ManagerName { get; set; } = null!;

    /// <summary>
    /// merchant activation date
    /// </summary>
    public DateOnly AgreementDate { get; set; }

    /// <summary>
    /// merchant phone
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// 1=&gt;pf provider, 0=&gt;not pf provider
    /// </summary>
    public byte? PspFlag { get; set; }

    /// <summary>
    /// 0=&gt;individual, 1=&gt;have sub merchants, 2=&gt; submerchant
    /// </summary>
    public byte? MainSellerFlag { get; set; }

    /// <summary>
    /// Main dealer TC Identity
    /// </summary>
    public string? MainSellerTaxNo { get; set; }

    public string? Latitude { get; set; }

    public string? Longitude { get; set; }

    /// <summary>
    ///  national address database (UAVT) code
    /// </summary>
    public string? NationalAddressCode { get; set; }

    /// <summary>
    /// geographical location in json
    /// </summary>
    public string? Geocodeinfo { get; set; }

    /// <summary>
    /// merchant name on IKS
    /// </summary>
    public string? MerchantName { get; set; }

    /// <summary>
    /// additional response in json
    /// </summary>
    public string? AdditionalInfo { get; set; }

    /// <summary>
    /// status on iks: 0=&gt;Iks open, 1=&gt;Iks closed
    /// </summary>
    public byte StatusCode { get; set; }

    /// <summary>
    /// 1=&gt;active, 2=&gt;invalid, 3=&gt;terminated
    /// </summary>
    public byte Status { get; set; }

    /// <summary>
    /// short coed of termination
    /// </summary>
    public string? Code { get; set; }

    /// <summary>
    /// Termination Date
    /// </summary>
    public DateOnly? TerminationDate { get; set; }

    /// <summary>
    /// 0=&gt; terminated, 1 active but not with us, 2=&gt; both active
    /// </summary>
    public sbyte? ActivityType { get; set; }

    /// <summary>
    /// (9=&gt; merchant terminated, 8=&gt;merchant termination reversed
    /// </summary>
    public sbyte? InformType { get; set; }

    /// <summary>
    /// Explanation  for terminated
    /// </summary>
    public string? Explanation { get; set; }

    /// <summary>
    /// Personnel name  for terminated
    /// </summary>
    public string? PersonnelName { get; set; }

    /// <summary>
    /// Merchant TCKN
    /// </summary>
    public string? OwnerIdentityNo { get; set; }

    /// <summary>
    /// multiple partners of company
    /// </summary>
    public string? Partner2IdentityNo { get; set; }

    /// <summary>
    /// multiple partners of company
    /// </summary>
    public string? Partner3IdentityNo { get; set; }

    /// <summary>
    /// multiple partners of company
    /// </summary>
    public string? Partner4IdentityNo { get; set; }

    /// <summary>
    /// multiple partners of company
    /// </summary>
    public string? Partner5IdentityNo { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
