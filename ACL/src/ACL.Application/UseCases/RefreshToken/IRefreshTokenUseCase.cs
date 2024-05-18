using ACL.Application.UseCases.RefreshToken.Request;
using ACL.Application.UseCases.RefreshToken.Response;

namespace ACL.Application.UseCases.RefreshToken
{
    public interface IRefreshTokenUseCase : IUseCase<RefreshTokenRequest, RefreshTokenResponse>
    {
    }
}
