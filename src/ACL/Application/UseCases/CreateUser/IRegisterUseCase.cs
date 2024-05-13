using ACL.Application.UseCases.CreateUser.Request;
using ACL.Application.UseCases.CreateUser.Response;

namespace ACL.Application.UseCases.CreateUser
{
    public interface IRegisterUseCase : IUseCase<RegisterRequest, RegisterResponse>
    {
    }
}
