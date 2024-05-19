using ACL.Application.UseCases.Auth.Register.Request;
using ACL.Application.UseCases.Auth.Register.Response;

namespace ACL.Application.UseCases.Auth.Register
{
    public interface IRegisterUseCase : IUseCase<RegisterRequest, RegisterResponse>
    {
    }
}
