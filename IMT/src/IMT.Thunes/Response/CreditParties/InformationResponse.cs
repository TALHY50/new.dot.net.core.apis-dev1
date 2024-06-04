using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMT.Thunes.Response.CreditParties
{
    public class InformationResponse
    {
        public int StatusCode { get; set; }
        public string ReasonPhrase { get; set; }
        public string Version { get; set; }
    }
}