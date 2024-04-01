using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class MerchantApplicationComment
{
    public int Id { get; set; }

    /// <summary>
    /// merchant_applications table primary id
    /// </summary>
    public int ApplicationId { get; set; }

    /// <summary>
    /// users id of sales admin and sales expert 
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// merchant application users comment
    /// </summary>
    public string Comment { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
