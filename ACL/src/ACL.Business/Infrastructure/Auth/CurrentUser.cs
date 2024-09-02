using ACL.Business.Application;
using ACL.Business.Application.Behaviours;
using ACL.Business.Application.Interfaces.Services;
using ACL.Business.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using SharedKernel.Main.Application.Interfaces.Services;

namespace ACL.Business.Infrastructure.Auth;

public class CurrentUser : IUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IIdentity _authenToken;

    public CurrentUser(IHttpContextAccessor httpContextAccessor, IIdentity authenToken)
    {
        this._httpContextAccessor = httpContextAccessor;
        this._authenToken = authenToken;
    }
    

    // public uint? Id => this._authenToken.GetUserIdFromToken(HttpContextAccessor.HttpContext.Request.Headers[HeaderNames.Authorization]);
    public uint? Id { get; }
}