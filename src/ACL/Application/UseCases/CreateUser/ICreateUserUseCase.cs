using ACL.Application.UseCases.CreateUser.Request;
using ACL.Application.UseCases.CreateUser.Response;

namespace ACL.Application.UseCases.CreateUser
{
    public interface ICreateUserUseCase : IUseCase<CreateUserRequest, CreateUserResponse>
    {
    }
}
