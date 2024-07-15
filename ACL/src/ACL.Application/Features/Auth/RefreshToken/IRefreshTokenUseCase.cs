﻿using ACL.Application.Features.Auth.RefreshToken.Request;
using ACL.Application.Features.Auth.RefreshToken.Response;

namespace ACL.Application.Features.Auth.RefreshToken
{
    public interface IRefreshTokenUseCase : IUseCase<RefreshTokenRequest, RefreshTokenResponse>
    {
    }
}
