using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class GovBtransOkkib
{
    public int Id { get; set; }

    public string? RecordType { get; set; }

    /// <summary>
    /// unique id for every record	
    /// </summary>
    public string? RecordUniqueId { get; set; }

    public string? TransactionId { get; set; }

    public string? OperationType { get; set; }

    public string? CardHolderVkn { get; set; }

    public string? CardHolderTitle { get; set; }

    public string? CardHolderName { get; set; }

    public string? CardHolderSurname { get; set; }

    public string? CardHolderIdType { get; set; }

    public string? CardHolderTckn { get; set; }

    public string? CardNo { get; set; }

    public string? BankType { get; set; }

    public string? BankEftCode { get; set; }

    public string? BankAtmCode { get; set; }

    public string? ProcessDate { get; set; }

    public decimal? TransactionAmount { get; set; }

    public decimal? NetAmount { get; set; }

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
