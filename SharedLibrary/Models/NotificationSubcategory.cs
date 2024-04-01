using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class NotificationSubcategory
{
    public uint Id { get; set; }

    public uint NotificationCategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
