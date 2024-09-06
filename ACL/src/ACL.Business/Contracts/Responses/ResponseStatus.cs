using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACL.Business.Contracts.Responses
{
    public class ResponseStatus
    {
        public string Code { get; set; }
        public string Message { get; set; }

        public static ResponseStatus Success => new ResponseStatus { Code = "100", Message = "Successful" };
        public static ResponseStatus AuthenticationFailed => new ResponseStatus { Code = "401", Message = "Authentication failed: invalid email or password." };
        public static ResponseStatus UnexpectedError => new ResponseStatus { Code = "500", Message = "An unexpected error occurred." };
    }

}
