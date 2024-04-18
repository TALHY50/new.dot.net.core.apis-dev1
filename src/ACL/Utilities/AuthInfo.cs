namespace ACL.Utilities
{
    public class AuthInfoModel
    {
        //public AuthInfo AuthInfo { get; set; }
        //public string AccessToken { get; set; }
        //public DateTime Expiry { get; set; }
        //public string RefreshToken { get; set; }
        //public object PermissionList { get; set; }
        public ulong UserId { get; set; }
        public ulong CompanyId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public ulong UserType { get; set; }
        public string UserGroupIds { get; set; }
        public AuthInfoModel(ulong userId, ulong companyId, string email, string name, string phone, ulong userType, string userGroupIds)
        {
            UserId = userId;
            CompanyId = companyId;
            Email = email;
            Name = name;
            Phone = phone;
            UserType = userType;
            UserGroupIds = userGroupIds;
        }

        //public AuthInfoModel(object authInfo, string accessToken, DateTime expiry, string refreshToken, object permissionList)
        //{
        //    AuthInfo = (AuthInfo)authInfo;
        //    AccessToken = accessToken;
        //    Expiry = expiry;
        //    RefreshToken = refreshToken;
        //    PermissionList = permissionList;
        //}


    }

    public static class AppAuth
    {
        private static AuthInfoModel _authInfo;

        // Set authentication information
        public static void SetAuthInfo(AuthInfoModel authInfo)
        {
            _authInfo = authInfo;
        }

        // Get the authentication information
        public static AuthInfoModel GetAuthInfo()
        {
            return _authInfo;
        }
    }

    public class AuthInfo
    {
        public ulong UserId { get; set; }
        public ulong CompanyId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public ulong UserType { get; set; }
        public string UserGroupIds { get; set; }
    }
}
