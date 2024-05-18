using ACL.UseCases.UseCases.Login.Request;
using ACL.UseCases.UseCases.Login.Response;

namespace ACL.UseCases.UseCases.Login
{
    public interface ILoginUseCase : IUseCase<LoginRequest, LoginResponse>
    {
    }
}
