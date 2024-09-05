namespace ACL.Web.Presentation.Routes
{
    public class PageRoutes
    {
        public const string GetPageMethod = "GET";
        public const string GetPageName = "pages";
        public const string GetPageTemplate = "/pages";

        public const string GetPageByIdMethod = "GET";
        public const string GetPageByIdName = "get_page_by_id";
        public const string GetPageByIdTemplate = "/pages/{id}";

        public const string CreatePageMethod = "POST";
        public const string CreatePageName = "create_page";
        public const string CreatePageTemplate = "/pages";

        public const string DeletePageMethod = "DELETE";
        public const string DeletePageName = "delete_page_by_id";
        public const string DeletePageTemplate = "/pages/{id}";

        public const string UpdatePageMethod = "PUT";
        public const string UpdatePageName = "update_page_by_id";
        public const string UpdatePageTemplate = "/pages/{id}";
    }
}
