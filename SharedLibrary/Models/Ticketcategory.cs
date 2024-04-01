using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class Ticketcategory
{
    public uint Id { get; set; }

    public string? Name { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
