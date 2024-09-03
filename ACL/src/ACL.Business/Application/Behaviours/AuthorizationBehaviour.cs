using System.Reflection;
using ACL.Business.Application.Features.Auth;
using ACL.Business.Application.Interfaces.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using SharedKernel.Main.Application.Extensions;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Infrastructure.Attributes;

namespace ACL.Business.Application.Behaviours;

public class AuthorizationBehaviour<TRequest, TResponse>(
    IHttpContextAccessor httpContextAccessor,
    ISender? mediator
    )
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
    private ISender? _mediator = mediator;
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
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
                    var payload =  _httpContextAccessor.HttpContext.RequestBodyFromItem();
                    var result = await _mediator.Send(new ValidateJwtTokenCommand(token, payload), cancellationToken);
                    if(! result.Equals(true))
                        throw new UnauthorizedAccessException(result.FirstError.Description);
                }
                else
                {
                    throw new UnauthorizedAccessException("Bearer token not found.");
                }
            }
        }
        
        return await next();
    }
   
}