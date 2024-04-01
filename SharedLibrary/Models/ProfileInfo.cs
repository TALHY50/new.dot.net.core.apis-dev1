using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class ProfileInfo
{
    public uint Id { get; set; }

    public int? UserId { get; set; }

    public string? DocumentType { get; set; }

    public string? Document { get; set; }

    public string? PhoneNumber { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
