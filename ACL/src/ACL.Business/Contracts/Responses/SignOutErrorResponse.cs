﻿namespace ACL.Business.Contracts.Responses
{
    public class SignOutErrorResponse : SignOutResponse
    {
        public string Message { get;  set; }
        public string Code { get;  set; }
    }
}