using ACL.Application.Common;
using ACL.Application.Domain.Ports.Services.Token;
using Microsoft.AspNetCore.Http;

namespace ACL.Application.Infrastructure.Services;

public class CurrentUser : IUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IAuthTokenService _authenTokenService;

    public CurrentUser(IHttpContextAccessor httpContextAccessor, IAuthTokenService authenTokenService)
    {
        this._httpContextAccessor = httpContextAccessor;
        this._authenTokenService = authenTokenService;
    }
    

    // public uint? Id => this._authenTokenService.GetUserIdFromToken(HttpContextAccessor.HttpContext.Request.Headers[HeaderNames.Authorization]);
    public uint? Id { get; }
}