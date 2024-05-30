using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMT.Thunes.Response.Common
{
    public class Payer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public string CountryIsoCode { get; set; }
        public Service Service { get; set; }
    }
}