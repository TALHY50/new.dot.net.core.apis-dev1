using System.Reflection;
using MediatR;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Infrastructure.Attributes;

namespace SharedKernel.Main.Application.Behaviours;

public class AuthorizationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ICurrentUser _currentUser;

    public AuthorizationBehaviour(
        ICurrentUser currentUser)
    {
        _currentUser = currentUser;
    }

    public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var authorizeAttributes = request.GetType().GetCustomAttributes<AuthorizeAttribute>();

        if (authorizeAttributes.Any())
        {
            // Must be authenticated user
            if (_currentUser.UserId == null)
            {
                throw new UnauthorizedAccessException();
            }
        }

        // User is authorized / authorization not required
        return next();
    }
}