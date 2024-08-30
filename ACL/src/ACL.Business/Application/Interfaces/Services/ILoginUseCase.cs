using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;
using SharedKernel.Main.Application.Common;

namespace ACL.Business.Application.Interfaces.Services
{
    public interface ILoginUseCase : IUseCase<LoginRequest, LoginResponse>
    {
    }
}
