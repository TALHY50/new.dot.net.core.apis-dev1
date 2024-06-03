using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMT.Thunes.Response.Common;

namespace IMT.Thunes.Response
{
    public class CreateQuatationResponse : BaseCreateQuatationResponse
    {
        public ErrorResponse errorResponse { get; set; }
    }
}