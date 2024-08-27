using System;
using System.Collections.Generic;

namespace SharedKernel.Main.Domain.IMT.Entities;

public partial class Quotation
{
    public int Id { get; set; }

    public uint? InstitutionId { get; set; }

    public uint? InvoiceId { get; set; }

    public string OrderId { get; set; } = null!;

    public uint MttId { get; set; }

    /// <summary>
    /// SOURCE_AMOUNT,DESTINATION_AMOUNT
    /// </summary>
    public int Mode { get; set; }

    public decimal? SourceAmount { get; set; }

    public decimal? DestinationAmount { get; set; }

    public DateTime? ExpirationDate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
