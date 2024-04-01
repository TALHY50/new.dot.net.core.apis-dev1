using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class ArchievedSaleBilling
{
    public int Id { get; set; }

    public int MerchantId { get; set; }

    public int SaleId { get; set; }

    public string? CardHolderName { get; set; }

    public string ExtraCardHolderName { get; set; } = null!;

    public string? CardNumber { get; set; }

    public string? ExpiryMonth { get; set; }

    public string? ExpiryYear { get; set; }

    public string? Cvv { get; set; }

    public string? BillName { get; set; }

    public string? BillSurname { get; set; }

    public string? BillAddress1 { get; set; }

    public string? BillAddress2 { get; set; }

    public string? BillCity { get; set; }

    public string? BillPostcode { get; set; }

    public string? BillState { get; set; }

    public string? BillCountry { get; set; }

    public string? BillEmail { get; set; }

    public string? BillPhone { get; set; }

    /// <summary>
    /// created by merchant user id
    /// </summary>
    public int? CreatedBy { get; set; }

    /// <summary>
    /// created by merchant user name
    /// </summary>
    public string? CreatedByName { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? BillTckn { get; set; }

    public string? BillTaxNo { get; set; }

    public string? BillTaxOffice { get; set; }

    public sbyte? CustomerType { get; set; }

    public sbyte MigrationStatus { get; set; }
}
