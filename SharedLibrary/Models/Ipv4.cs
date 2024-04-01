using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class Ipv4
{
    public uint Id { get; set; }

    public ulong? StartIpRange { get; set; }

    public ulong? EndIpRange { get; set; }

    public string? CountryCode { get; set; }

    public string? CountryName { get; set; }
}
