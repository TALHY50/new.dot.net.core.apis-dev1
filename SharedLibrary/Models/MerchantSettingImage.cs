using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class MerchantSettingImage
{
    public int Id { get; set; }

    public int MerchantSettingId { get; set; }

    public string ImageName { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
