namespace Admin.App.Presentation.Routes
{
    public class InstitutionFundRoutes
    {
        public const string GetInstitutionFundMethod = "GET";
        public const string GetInstitutionFundName = "institution_funds";
        public const string GetInstitutionFundTemplate = "/institution_funds";

        public const string GetInstitutionFundByIdMethod = "GET";
        public const string GetInstitutionFundByIdName = "get_institution_fund_by_id";
        public const string GetInstitutionFundByIdTemplate = "/institution_funds/{id}";

        public const string CreateInstitutionFundMethod = "POST";
        public const string CreateInstitutionFundName = "create_institution_funds";
        public const string CreateInstitutionFundTemplate = "/institution_funds";

        public const string DeleteInstitutionFundMethod = "DELETE";
        public const string DeleteInstitutionFundName = "delete_institution_funds_by_id";
        public const string DeleteInstitutionFundTemplate = "/institution_funds/{id}";

        public const string UpdateInstitutionFundMethod = "PUT";
        public const string UpdateInstitutionFundName = "update_institution_funds_by_id";
        public const string UpdateInstitutionFundTemplate = "/institution_funds/{id}";
    }
}
