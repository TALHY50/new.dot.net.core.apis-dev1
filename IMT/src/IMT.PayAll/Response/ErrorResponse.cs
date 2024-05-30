using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMT.PayAll.Response
{
    internal class ErrorResponse
    {
            public int StatusCode { get; set; }
            public string ReasonPhrase { get; set; }
            public string Version { get; set; }
            public Dictionary<string, string> Headers { get; set; }
            public string Content { get; set; }

    }
}
