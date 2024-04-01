using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class WrongPasswordHistory
{
    /// <summary>
    /// primary key of this table
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// primary key of users table
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// created date time
    /// </summary>
    public DateTime CreatedAt { get; set; }
}
