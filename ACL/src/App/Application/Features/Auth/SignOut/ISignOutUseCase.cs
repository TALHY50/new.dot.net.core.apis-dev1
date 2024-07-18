using App.Application.Features.Auth.SignOut.Request;
using App.Application.Features.Auth.SignOut.Response;

namespace App.Application.Features.Auth.SignOut
{
    /// <inheritdoc/>
    public interface ISignOutUseCase : IUseCase<SignOutRequest, SignOutResponse>
    {

    }
}
