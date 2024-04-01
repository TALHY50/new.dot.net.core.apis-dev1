using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class Post
{
    public uint Id { get; set; }

    public int AuthorId { get; set; }

    public int? CategoryId { get; set; }

    public string Title { get; set; } = null!;

    public string? SeoTitle { get; set; }

    public string? Excerpt { get; set; }

    public string Body { get; set; } = null!;

    public string? Image { get; set; }

    public string Slug { get; set; } = null!;

    public string? MetaDescription { get; set; }

    public string? MetaKeywords { get; set; }

    public string Status { get; set; } = null!;

    public bool Featured { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
