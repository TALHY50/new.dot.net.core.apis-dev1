using App.Application.Features.Auth.RefreshToken.Request;
using App.Application.Features.Auth.RefreshToken.Response;

namespace App.Application.Features.Auth.RefreshToken
{
    public interface IRefreshTokenUseCase : IUseCase<RefreshTokenRequest, RefreshTokenResponse>
    {
    }
}
