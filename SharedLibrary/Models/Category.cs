using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class Category
{
    public uint Id { get; set; }

    public uint? ParentId { get; set; }

    public int Order { get; set; }

    public string Name { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Category> InverseParent { get; set; } = new List<Category>();

    public virtual Category? Parent { get; set; }
}
