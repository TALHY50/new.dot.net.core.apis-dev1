using ACL.Application.UseCases.Auth.RefreshToken.Request;
using ACL.Application.UseCases.Auth.RefreshToken.Response;

namespace ACL.Application.UseCases.Auth.RefreshToken
{
    public interface IRefreshTokenUseCase : IUseCase<RefreshTokenRequest, RefreshTokenResponse>
    {
    }
}
