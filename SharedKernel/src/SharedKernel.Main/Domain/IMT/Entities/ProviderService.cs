using System;
using System.Collections.Generic;

namespace SharedKernel.Main.Domain.IMT.Entities;

public partial class ProviderService
{
    public int Id { get; set; }

    public int ImtProviderId { get; set; }

    public string? Name { get; set; }

    public int? CreatedById { get; set; }

    public int? UpdatedById { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
