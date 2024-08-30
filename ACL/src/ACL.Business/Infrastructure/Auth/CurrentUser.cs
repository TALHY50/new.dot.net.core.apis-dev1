using ACL.Business.Application;
using ACL.Business.Application.Interfaces.Services;
using ACL.Business.Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace ACL.Business.Infrastructure.Auth;

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