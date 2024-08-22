using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Contracts.ACL.Request;
using SharedKernel.Main.Contracts.ACL.Response;

namespace SharedKernel.Main.Application.Interfaces.UseCases.ACL
{
    public interface ILoginUseCase : IUseCase<LoginRequest, LoginResponse>
    {
    }
}
