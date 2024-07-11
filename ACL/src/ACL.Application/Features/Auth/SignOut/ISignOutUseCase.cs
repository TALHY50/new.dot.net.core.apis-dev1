﻿using Notification.Application.Features.Auth.SignOut.Request;
using Notification.Application.Features.Auth.SignOut.Response;

namespace ACL.Application.Features.Auth.SignOut
{
    /// <inheritdoc/>
    public interface ISignOutUseCase : IUseCase<SignOutRequest, SignOutResponse>
    {

    }
}
