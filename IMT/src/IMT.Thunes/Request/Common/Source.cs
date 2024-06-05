using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMT.Thunes.Request.Common
{
    public class Source1
    {
        public required string amount { get; set; }
        public required string currency { get; set; }
        public required string country_iso_code { get; set; }
    }
}