using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class Content
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? ContentEn { get; set; }

    public string? ContentTr { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
