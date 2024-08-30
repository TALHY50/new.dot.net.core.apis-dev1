using System.ComponentModel;
using SharedKernel.Main.Contracts.Common;

namespace ACL.Bussiness.Contracts.Requests
{
    public class LoginRequest : Request
    {
        [DefaultValue("ssadmin@sipay.com.tr")]
        public string Email { get; set; }
        [DefaultValue("Nop@ss1234")]
        public string Password { get; set; }
    }
}
