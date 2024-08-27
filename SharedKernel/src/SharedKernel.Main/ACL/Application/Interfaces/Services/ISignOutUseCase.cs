using SharedKernel.Main.ACL.Contracts.Requests;
using SharedKernel.Main.ACL.Contracts.Responses;
using SharedKernel.Main.Application.Common;

namespace SharedKernel.Main.ACL.Application.Interfaces.Services
{
    /// <inheritdoc/>
    public interface ISignOutUseCase : IUseCase<SignOutRequest, SignOutResponse>
    {

    }
}
