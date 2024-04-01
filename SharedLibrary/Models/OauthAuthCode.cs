using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class OauthAuthCode
{
    public string Id { get; set; } = null!;

    public int UserId { get; set; }

    public uint ClientId { get; set; }

    public string? Scopes { get; set; }

    public bool Revoked { get; set; }

    public DateTime? ExpiresAt { get; set; }
}
