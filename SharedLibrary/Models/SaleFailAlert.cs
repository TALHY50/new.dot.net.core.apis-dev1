using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class SaleFailAlert
{
    public int Id { get; set; }

    public int? MaxNoOfFailedAttempt { get; set; }

    public int? CurrentNoOfFailedAttempt { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
