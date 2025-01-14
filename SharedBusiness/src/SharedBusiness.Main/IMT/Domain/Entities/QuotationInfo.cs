﻿using Ardalis.SharedKernel;

namespace SharedBusiness.Main.IMT.Domain.Entities;

public partial class QuotationInfo :EntityBase<uint>,IAggregateRoot
{
    public decimal? RequestAmount { get; set; }

    public uint? CurrencyId { get; set; }

    public decimal? Commission { get; set; }

    public decimal? CommisionFixed { get; set; }

    public decimal? CommissionPercentage { get; set; }

    public decimal? Cot { get; set; }

    public decimal? CotPercentage { get; set; }

    public decimal? CotFixed { get; set; }

    public decimal? MarkUp { get; set; }

    public decimal? MarkUpPercentage { get; set; }

    public decimal? MarkUpFixed { get; set; }

    public decimal? Tax { get; set; }

    public decimal? TaxPercentage { get; set; }

    public decimal? TaxFixed { get; set; }

    public decimal? SentAmount { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
