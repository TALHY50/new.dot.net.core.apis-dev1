using ACL.Application.UseCases.Register.Request;
using ACL.Application.UseCases.Register.Response;

namespace ACL.Application.UseCases.Register
{
    public interface IRegisterUseCase : IUseCase<RegisterRequest, RegisterResponse>
    {
    }
}
