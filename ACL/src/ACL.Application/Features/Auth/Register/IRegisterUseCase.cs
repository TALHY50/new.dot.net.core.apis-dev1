using Notification.Application.Features.Auth.Register.Request;
using Notification.Application.Features.Auth.Register.Response;

namespace ACL.Application.Features.Auth.Register
{
    public interface IRegisterUseCase : IUseCase<RegisterRequest, RegisterResponse>
    {
    }
}
