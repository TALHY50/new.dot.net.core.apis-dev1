﻿using Ardalis.SharedKernel;

namespace SharedBusiness.Main.IMT.Domain.Entities;

public partial class Quotation :EntityBase<uint>,IAggregateRoot
{

    public uint? InstitutionId { get; set; }

    public string? InvoiceId { get; set; }

    public string OrderId { get; set; } = null!;

    public uint MttId { get; set; }

    /// <summary>
    /// SOURCE_AMOUNT,DESTINATION_AMOUNT
    /// </summary>
    public int Mode { get; set; }

    public decimal? SourceAmount { get; set; }

    public decimal? DestinationAmount { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
