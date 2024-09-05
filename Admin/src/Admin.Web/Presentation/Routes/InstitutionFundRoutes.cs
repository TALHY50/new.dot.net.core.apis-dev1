namespace Admin.Web.Presentation.Routes
{
    public class InstitutionFundRoutes
    {
        public const string GetInstitutionFundMethod = "GET";
        public const string GetInstitutionFundName = "institution-funds";
        public const string GetInstitutionFundTemplate = "/institution-funds";

        public const string GetInstitutionFundByIdMethod = "GET";
        public const string GetInstitutionFundByIdName = "get-institution-fund-by-id";
        public const string GetInstitutionFundByIdTemplate = "/institution-funds/{id}";

        public const string CreateInstitutionFundMethod = "POST";
        public const string CreateInstitutionFundName = "create-institution-fund";
        public const string CreateInstitutionFundTemplate = "/institution-funds";

        public const string DeleteInstitutionFundMethod = "DELETE";
        public const string DeleteInstitutionFundName = "delete-institution-fund-by-id";
        public const string DeleteInstitutionFundTemplate = "/institution-funds/{id}";

        public const string UpdateInstitutionFundMethod = "PUT";
        public const string UpdateInstitutionFundName = "update-institution-fund-by-id";
        public const string UpdateInstitutionFundTemplate = "/institution-funds/{id}";
    }
}
