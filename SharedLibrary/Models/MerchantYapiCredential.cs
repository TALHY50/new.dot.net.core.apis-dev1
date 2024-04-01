using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class MerchantYapiCredential
{
    public int Id { get; set; }

    public int MerchantId { get; set; }

    public string ApplicationId { get; set; } = null!;

    public string BasicToken { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
