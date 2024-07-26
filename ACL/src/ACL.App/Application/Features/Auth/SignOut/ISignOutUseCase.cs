using ACL.App.Application.Features.Auth.SignOut.Request;
using ACL.App.Application.Features.Auth.SignOut.Response;

namespace ACL.App.Application.Features.Auth.SignOut
{
    /// <inheritdoc/>
    public interface ISignOutUseCase : IUseCase<SignOutRequest, SignOutResponse>
    {

    }
}
