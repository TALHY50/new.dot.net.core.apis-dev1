using System.Security.Claims;
using ACL.App.Domain.Auth;
using ACL.App.Infrastructure.Persistence.Configurations;

namespace ACL.App.Infrastructure.Utilities
{
    public class AuthInfoModel
    {
        public ulong UserId { get; set; }
        public ulong CompanyId { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public ulong? UserType { get; set; }
        public string? UserGroupIds { get; set; }
        public string? Language { get; set; } = "en-US";


    }

    public static class AppAuth
    {
        private static AuthInfoModel? _authInfo;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private static IHttpContextAccessor _httpContextAccessor;
        private static ApplicationDbContext _dbContext;

        public static void Initialize(IHttpContextAccessor httpContextAccessor, ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
        }
        public static void SetAuthInfo(IHttpContextAccessor? httpContextAccessor = null, AuthInfoModel? authInfo = null)
        {
            if (authInfo == null)
            {
#pragma warning disable CS8601 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
                _httpContextAccessor = httpContextAccessor;
                var user = _httpContextAccessor?.HttpContext?.User;
                if (user?.Identity?.IsAuthenticated ?? false)
                {
                    var userIdClaim = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                    if (userIdClaim != null)
                    {
                        var userId = ulong.Parse(userIdClaim.Value);
                        AclUser? userFromDb = _dbContext.AclUsers.Find(userId); // Fetch user data from the database
                        var userGroupIds = (from auu in _dbContext.AclUserUsergroups
                                            where auu.UserId == userId
                                            select auu.UsergroupId.ToString()).ToList();

                        string concatenatedIds = string.Join(",", userGroupIds);
                        authInfo = new AuthInfoModel
                        {
                            CompanyId = userFromDb?.CompanyId ?? 0,
                            UserId = ulong.Parse(userIdClaim.Value),
                            Email = userFromDb?.Email,
                            Name = userFromDb?.Username,
                            Phone = userFromDb?.Phone,
                            UserType = userFromDb?.UserType,
                            UserGroupIds = concatenatedIds,
                            Language = userFromDb?.Language
                        };
                    }
                }
                else
                {
                    authInfo = new AuthInfoModel
                    {
                        UserId = 0,
                        CompanyId = 0,
                        Email = "user@example.com",
                        Name = "test",
                        Phone = "12345678",
                        UserType = 1,
                        UserGroupIds = "2",
                        Language = "en-US"
                    };
                }
            }

            _authInfo = authInfo;
        }


        // Get the authentication information
        public static AuthInfoModel? GetAuthInfo()
        {
            return _authInfo;
        }
    }

}
