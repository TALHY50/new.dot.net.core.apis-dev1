using ACL.App.Application.Features.Auth.Register.Request;
using ACL.App.Application.Features.Auth.Register.Response;

namespace ACL.App.Application.Features.Auth.Register
{
    public interface IRegisterUseCase : IUseCase<RegisterRequest, RegisterResponse>
    {
    }
}
