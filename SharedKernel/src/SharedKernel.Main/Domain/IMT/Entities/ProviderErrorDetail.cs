using System;
using System.Collections.Generic;

namespace SharedKernel.Main.Domain.IMT.Entities;

public partial class ProviderErrorDetail
{
    public int Id { get; set; }

    public int ImtProviderId { get; set; }

    public sbyte Type { get; set; }

    public int ReferenceId { get; set; }

    public string? ErrorCode { get; set; }

    public string? ErrorMessage { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
