using ACL.Application.Features.Auth.Register.Request;
using ACL.Application.Features.Auth.Register.Response;

namespace ACL.Application.Features.Auth.Register
{
    public interface IRegisterUseCase : IUseCase<RegisterRequest, RegisterResponse>
    {
    }
}
