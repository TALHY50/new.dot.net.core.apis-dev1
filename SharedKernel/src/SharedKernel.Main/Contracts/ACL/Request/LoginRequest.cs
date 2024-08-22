using System.ComponentModel;

namespace SharedKernel.Main.Contracts.ACL.Request
{
    public class LoginRequest : SharedKernel.Main.Contracts.Common.Request
    {
        [DefaultValue("ssadmin@sipay.com.tr")]
        public string Email { get; set; }
        [DefaultValue("Nop@ss1234")]
        public string Password { get; set; }
    }
}
