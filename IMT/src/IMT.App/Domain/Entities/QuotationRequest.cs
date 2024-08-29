using System;
using System.Collections.Generic;

namespace IMT.App.Domain.Entities;

public partial class QuotationRequest
{
    public uint Id { get; set; }

    public string? Request { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
