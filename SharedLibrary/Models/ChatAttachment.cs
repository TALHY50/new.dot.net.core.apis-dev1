using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class ChatAttachment
{
    public ulong Id { get; set; }

    public ulong MessageId { get; set; }

    public string Type { get; set; } = null!;

    public string File { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string Name { get; set; } = null!;
}
