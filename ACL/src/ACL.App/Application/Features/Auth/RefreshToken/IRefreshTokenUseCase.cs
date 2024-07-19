using ACL.App.Application.Features.Auth.RefreshToken.Request;
using ACL.App.Application.Features.Auth.RefreshToken.Response;

namespace ACL.App.Application.Features.Auth.RefreshToken
{
    public interface IRefreshTokenUseCase : IUseCase<RefreshTokenRequest, RefreshTokenResponse>
    {
    }
}
