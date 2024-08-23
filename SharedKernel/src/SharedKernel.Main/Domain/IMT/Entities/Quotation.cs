using System;
using System.Collections.Generic;

namespace SharedKernel.Main.Domain.IMT.Entities;

public partial class Quotation
{
    public int Id { get; set; }

    public string OrderId { get; set; } = null!;

    public string PayerId { get; set; } = null!;

    public string Mode { get; set; } = null!;

    public string TransactionType { get; set; } = null!;

    public decimal? SourceAmount { get; set; }

    public int? ImtSourceCurrencyId { get; set; }

    public int? ImtProviderId { get; set; }

    public int? ImtProviderServiceId { get; set; }

    public int? ImtSourceCountryId { get; set; }

    public decimal? DestinationAmount { get; set; }

    public int? ImtDestinationCurrencyId { get; set; }

    public DateTime? CreatedAt { get; set; }
}
