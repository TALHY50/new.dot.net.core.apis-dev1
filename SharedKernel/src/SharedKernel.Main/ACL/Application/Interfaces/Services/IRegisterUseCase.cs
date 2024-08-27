﻿using SharedKernel.Main.ACL.Contracts.Requests;
using SharedKernel.Main.ACL.Contracts.Responses;
using SharedKernel.Main.Application.Common;

namespace SharedKernel.Main.ACL.Application.Interfaces.Services
{
    public interface IRegisterUseCase : IUseCase<RegisterRequest, RegisterResponse>
    {
    }
}
