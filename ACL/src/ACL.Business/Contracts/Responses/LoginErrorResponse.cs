﻿namespace ACL.Business.Contracts.Responses
{
    public class LoginErrorResponse : LoginResponse
    {
        public string Message { get;  set; }
        public string Code { get;  set; }
    }
}