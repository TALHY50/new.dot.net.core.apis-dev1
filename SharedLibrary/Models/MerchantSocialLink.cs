using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class MerchantSocialLink
{
    public int Id { get; set; }

    /// <summary>
    /// merchant primary key(id)
    /// 
    /// 
    /// </summary>
    public int? MerchantId { get; set; }

    /// <summary>
    /// FACEBOOK = 1,TWITTER = 2,INSTAGRAM = 3,LINKEDIN = 4,YOUTUBE = 5
    /// </summary>
    public sbyte? Media { get; set; }

    /// <summary>
    /// Social media link
    /// </summary>
    public string? MediaLink { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
