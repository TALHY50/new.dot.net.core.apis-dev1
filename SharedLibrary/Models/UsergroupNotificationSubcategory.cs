using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class UsergroupNotificationSubcategory
{
    public uint Id { get; set; }

    public uint NotificationSubcategoryId { get; set; }

    public uint UsergroupId { get; set; }

    public sbyte IsSms { get; set; }

    public sbyte IsEmail { get; set; }

    public sbyte IsPush { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
