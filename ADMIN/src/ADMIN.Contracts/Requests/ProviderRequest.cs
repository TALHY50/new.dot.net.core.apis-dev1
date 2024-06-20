using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADMIN.Contracts.Requests
{
    public class ProviderRequest
    {
        public required string Name { get; set; }
        public string? Code { get; set; }
        public string? BaseUrl { get; set; }
    }
}