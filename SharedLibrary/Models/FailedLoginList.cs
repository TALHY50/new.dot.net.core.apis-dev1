using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class FailedLoginList
{
    public int Id { get; set; }

    public sbyte UserType { get; set; }

    public int UserId { get; set; }

    public DateTime FailedLoginTime { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
