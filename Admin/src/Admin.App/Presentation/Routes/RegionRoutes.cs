namespace Admin.App.Presentation.Routes
{
    public class RegionRoutes
    {
        public const string GetRegionMethod = "GET";
        public const string GetRegionName = "regions";
        public const string GetRegionTemplate = "/regions";

        public const string GetRegionByIdMethod = "GET";
        public const string GetRegionByIdName = "get_region_by_id";
        public const string GetRegionByIdTemplate = "/regions/{id}";

        public const string CreateRegionMethod = "POST";
        public const string CreateRegionName = "create_region";
        public const string CreateRegionTemplate = "/regions";

        public const string DeleteRegionMethod = "DELETE";
        public const string DeleteRegionName = "delete_region_by_id";
        public const string DeleteRegionTemplate = "/regions/{id}";

        public const string UpdateRegionMethod = "PUT";
        public const string UpdateRegionName = "update_region_by_id";
        public const string UpdateRegionTemplate = "/regions/{id}";
    }
}
