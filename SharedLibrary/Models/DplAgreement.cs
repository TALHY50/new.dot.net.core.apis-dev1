using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class DplAgreement
{
    public int Id { get; set; }

    public int DplSettingId { get; set; }

    public string? AgreementName { get; set; }

    public string? AgreementContent { get; set; }

    public sbyte SerialNo { get; set; }

    public sbyte Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
