using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class JwtServiceCredential
{
    
    public const int NEW_REFUND_REQUEST = 0;
    public const int MANUAL_BANK_REFUND_REQUEST = 1;

    public int Id { get; set; }

    public int ServiceId { get; set; }

    public string ServiceClientId { get; set; } = null!;

    public string ServiceClientSecret { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
