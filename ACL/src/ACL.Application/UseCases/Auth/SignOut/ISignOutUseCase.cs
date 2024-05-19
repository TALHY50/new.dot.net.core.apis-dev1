using ACL.Application.UseCases.Auth.SignOut.Request;
using ACL.Application.UseCases.Auth.SignOut.Response;

namespace ACL.Application.UseCases.Auth.SignOut
{
    /// <inheritdoc/>
    public interface ISignOutUseCase : IUseCase<SignOutRequest, SignOutResponse>
    {

    }
}
