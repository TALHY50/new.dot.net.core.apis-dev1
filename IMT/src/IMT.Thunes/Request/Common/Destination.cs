using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMT.Thunes.Request.Common
{
    public class Destination
    {
        public required string Amount { get; set; }
        public required string Currency { get; set; }
    }
}