namespace Admin.Web.Presentation.Routes
{
    public class InstitutionMttRoutes
    {
        public const string GetInstitutionMttMethod = "GET";
        public const string GetInstitutionMttName = "institutionMtts";
        public const string GetInstitutionMttTemplate = "/institutionMtts";

        public const string GetInstitutionMttByIdMethod = "GET";
        public const string GetInstitutionMttByIdName = "get_institutionMtt_by_id";
        public const string GetInstitutionMttByIdTemplate = "/institutionMtts/{id}";

        public const string CreateInstitutionMttMethod = "POST";
        public const string CreateInstitutionMttName = "create_institutionMtt";
        public const string CreateInstitutionMttTemplate = "/institutionMtts";

        public const string DeleteInstitutionMttMethod = "DELETE";
        public const string DeleteInstitutionMttName = "delete_institutionMtt_by_id";
        public const string DeleteInstitutionMttTemplate = "/institutionMtts/{id}";

        public const string UpdateInstitutionMttMethod = "PUT";
        public const string UpdateInstitutionMttName = "update_institutionMtt_by_id";
        public const string UpdateInstitutionMttTemplate = "/institutionMtts/{id}";
    }
}
