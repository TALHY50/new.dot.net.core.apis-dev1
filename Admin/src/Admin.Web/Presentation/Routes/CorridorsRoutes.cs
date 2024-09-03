namespace Admin.Web.Presentation.Routes
{
    public class CorridorsRoutes
    {
        public const string GetCorridorMethod = "GET";
        public const string GetCorridorName = "corridors";
        public const string GetCorridorTemplate = "/corridors";

        public const string GetCorridorByIdMethod = "GET";
        public const string GetCorridorByIdName = "get_corridor_by_id";
        public const string GetCorridorByIdTemplate = "/corridors/{id}";

        public const string CreateCorridorMethod = "POST";
        public const string CreateCorridorName = "create_corridor";
        public const string CreateCorridorTemplate = "/corridors";

        public const string DeleteCorridorMethod = "DELETE";
        public const string DeleteCorridorName = "delete_Corridor_by_id";
        public const string DeleteCorridorTemplate = "/corridors/{id}";

        public const string UpdateCorridorMethod = "PUT";
        public const string UpdateCorridorName = "update_Corridor_by_id";
        public const string UpdateCorridorTemplate = "/corridors/{id}";
    }
}
