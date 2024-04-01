using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class UserDocument
{
    public uint Id { get; set; }

    public int UserId { get; set; }

    public string Document { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
