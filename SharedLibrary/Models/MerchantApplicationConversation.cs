using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class MerchantApplicationConversation
{
    public int Id { get; set; }

    public int? ApplicationId { get; set; }

    public sbyte? Type { get; set; }

    public int? QuestionId { get; set; }

    public string? Answer { get; set; }

    public string? FilePath { get; set; }

    public int? CommentUserId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
