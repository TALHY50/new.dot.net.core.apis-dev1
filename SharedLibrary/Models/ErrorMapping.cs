using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class ErrorMapping
{
    public int Id { get; set; }

    public string? BankIdentity { get; set; }

    public string? ErrorCode { get; set; }

    public string? MessageEn { get; set; }

    public string? MessageTr { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int CreatedById { get; set; }

    public int UpdatedById { get; set; }
}
