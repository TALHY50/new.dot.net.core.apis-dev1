using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMT.Thunes.Response.Transfer.Quotation
{
    public class BaseCreateQuatationResponse
    {
        public int StatusCode { get; set; }
        public string ReasonPhrase { get; set; }
        public CreateContentQuatationResponse Content { get; set; }
        public string Version { get; set; }

    }
}