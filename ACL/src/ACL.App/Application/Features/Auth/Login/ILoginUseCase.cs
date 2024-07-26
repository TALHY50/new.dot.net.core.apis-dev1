using ACL.App.Application.Features.Auth.Login.Request;
using ACL.App.Application.Features.Auth.Login.Response;

namespace ACL.App.Application.Features.Auth.Login
{
    public interface ILoginUseCase : IUseCase<LoginRequest, LoginResponse>
    {
    }
}
