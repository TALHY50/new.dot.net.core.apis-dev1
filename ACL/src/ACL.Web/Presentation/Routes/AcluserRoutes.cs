namespace ACL.Web.Presentation.Routes
{
    public class AcluserRoutes
    {
        public const string Base = "/";
        public const string Model = "users";

        public const string GetUserMethod = "GET";
        public const string GetUserName = Model;
        public const string GetUserTemplate =  Model;

        public const string GetUserByIdMethod = "GET";
        public const string GetUserByIdName = "get_user_by_id";
        public const string GetUserByIdTemplate = Model + "/{id}";

        public const string CreateUserMethod = "POST";
        public const string CreateUserName = "create_User";
        public const string CreateUserTemplate = Model;

        public const string DeleteUserMethod = "DELETE";
        public const string DeleteUserName = "delete_user_by_id";
        public const string DeleteUserTemplate = Model + "/{id}";

        public const string UpdateUserMethod = "PUT";
        public const string UpdateUserName = "update_user_by_id";
        public const string UpdateUserTemplate = Model + "/{id}";

        public const string PartiallyUpdateUserMethod = "PATCH";
        public const string PartiallyUpdateUserName = "update_user_by_id";
        public const string PartiallyUpdateUserTemplate = Model + "/{id}";
    }
}
