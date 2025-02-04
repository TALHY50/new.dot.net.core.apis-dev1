﻿using System.Security.Claims;
using ACL.Business.Domain.Entities;
using ACL.Business.Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Http;

namespace ACL.Business.Infrastructure.Auth.Auth
{
    public class AuthInfoModel
    {
        public uint UserId { get; set; }
        public uint CompanyId { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public uint? UserType { get; set; }
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
                        var userId = uint.Parse(userIdClaim.Value);
                        User? userFromDb = _dbContext.AclUsers.Find(userId); // Fetch user data from the database
                        var userGroupIds = (from auu in _dbContext.AclUserUsergroups
                                            where auu.UserId == userId
                                            select auu.UsergroupId.ToString()).ToList();

                        string concatenatedIds = string.Join(",", userGroupIds);
                        authInfo = new AuthInfoModel
                        {
                            CompanyId = userFromDb?.CompanyId ?? 0,
                            UserId = uint.Parse(userIdClaim.Value),
                            Email = userFromDb?.Email,
                            Name = userFromDb?.UserName,
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
