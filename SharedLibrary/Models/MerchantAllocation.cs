using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class MerchantAllocation
{
    public int Id { get; set; }

    public int AllocationId { get; set; }

    public int MerchantId { get; set; }

    public string PosId { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
