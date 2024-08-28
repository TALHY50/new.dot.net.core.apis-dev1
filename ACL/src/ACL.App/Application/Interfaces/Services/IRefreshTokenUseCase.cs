using ACL.App.Contracts.Requests;
using ACL.App.Contracts.Responses;
using SharedKernel.Main.Application.Common;

namespace ACL.App.Application.Interfaces.Services
{
    public interface IRefreshTokenUseCase : IUseCase<RefreshTokenRequest, RefreshTokenResponse>
    {
    }
}
