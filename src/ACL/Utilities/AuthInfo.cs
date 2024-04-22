

namespace ACL.Utilities
{
    public class AuthInfoModel
    {
        public ulong UserId { get; set; }
        public ulong CompanyId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public ulong UserType { get; set; }
        public string UserGroupIds { get; set; }

       
    }

    public static class AppAuth
    {
        private static  AuthInfoModel _authInfo;

        // Set authentication information
        public static void SetAuthInfo(AuthInfoModel authInfo = null)
        {
            if(authInfo == null)
            {
                authInfo = new AuthInfoModel() { UserId = 2, CompanyId = 2, Email = "user@example.com", Name = "test", Phone = "12345678", UserType = 1, UserGroupIds = "1,2" };
            }
           
            _authInfo = authInfo;
           
        }

        // Get the authentication information
        public static AuthInfoModel GetAuthInfo()
        {
            return _authInfo;
        }
    }

}
