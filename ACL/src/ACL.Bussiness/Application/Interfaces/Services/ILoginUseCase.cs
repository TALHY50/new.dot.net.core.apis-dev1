using ACL.Bussiness.Contracts.Requests;
using ACL.Bussiness.Contracts.Responses;
using SharedKernel.Main.Application.Common;

namespace ACL.Bussiness.Application.Interfaces.Services
{
    public interface ILoginUseCase : IUseCase<LoginRequest, LoginResponse>
    {
    }
}
