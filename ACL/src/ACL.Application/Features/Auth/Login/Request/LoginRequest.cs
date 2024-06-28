using System.ComponentModel;

namespace ACL.Application.Features.Auth.Login.Request
{
    public class LoginRequest : Features.Request
    {
        [DefaultValue("ssadmin@sipay.com.tr")]
        public string Email { get; set; }
        [DefaultValue("Nop@ss1234")]
        public string Password { get; set; }
    }
}
