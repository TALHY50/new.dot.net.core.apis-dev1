using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Http;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Infrastructure.Attributes;

namespace SharedKernel.Main.Application.Behaviours;

public class AuthorizationBehaviour<TRequest, TResponse>(
    ICurrentUser currentUser,
    IHttpContextAccessor httpContextAccessor,
    IAuthToken token
    )
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ICurrentUser _currentUser = currentUser;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
    private readonly IAuthToken _token = token; 
    public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var authorizeAttributes = request.GetType().GetCustomAttributes<AuthorizeAttribute>();
        if (authorizeAttributes.Any())
        {
            if (_httpContextAccessor.HttpContext != null)
            {
                string? authorizationHeader = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
                if (authorizationHeader != null && authorizationHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                {
                    var token = authorizationHeader.Substring("Bearer ".Length).Trim();
                }
                else
                {
                    throw new UnauthorizedAccessException("Bearer token not found.");
                }
            }
        }
        
        return next();
    }
   
}