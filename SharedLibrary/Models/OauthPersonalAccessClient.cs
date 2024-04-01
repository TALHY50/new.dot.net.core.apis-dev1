using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class OauthPersonalAccessClient
{
    public uint Id { get; set; }

    public uint ClientId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
