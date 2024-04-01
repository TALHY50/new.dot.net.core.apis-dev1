using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class WixStateData
{
    public int Id { get; set; }

    public string IdempotencyKeyType { get; set; } = null!;

    public string IdempotencyKeyValue { get; set; } = null!;

    public string ResponseData { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
