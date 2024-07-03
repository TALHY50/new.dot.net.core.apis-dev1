using System;
using System.Collections.Generic;

namespace SharedLibrary.Models.IMT;

public partial class ImtProvider
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? BaseUrl { get; set; }

    /// <summary>
    /// api key and secret must be encrypted
    /// </summary>
    public string? ApiKey { get; set; }

    public string? ApiSecret { get; set; }

    public sbyte? Status { get; set; }

    public int? CreatedById { get; set; }

    public int? UpdatedById { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
