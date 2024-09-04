﻿using System.ComponentModel;
using SharedKernel.Main.Contracts;

namespace ACL.Business.Contracts.Requests
{
    public class LoginRequestOwn : Request
    {
        [DefaultValue("ssadmin@sipay.com.tr")]
        public string Email { get; set; }
        [DefaultValue("Nop@ss1234")]
        public string Password { get; set; }
    }
}