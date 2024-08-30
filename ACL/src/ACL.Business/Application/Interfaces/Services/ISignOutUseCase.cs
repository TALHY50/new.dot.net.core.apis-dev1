using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;
using SharedKernel.Main.Application.Common;

namespace ACL.Business.Application.Interfaces.Services
{
    /// <inheritdoc/>
    public interface ISignOutUseCase : IUseCase<SignOutRequest, SignOutResponse>
    {

    }
}
