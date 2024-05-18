using ACL.UseCases.UseCases.RefreshToken.Request;
using ACL.UseCases.UseCases.RefreshToken.Response;

namespace ACL.UseCases.UseCases.RefreshToken
{
    public interface IRefreshTokenUseCase : IUseCase<RefreshTokenRequest, RefreshTokenResponse>
    {
    }
}
