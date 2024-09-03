namespace Admin.Web.Presentation.Routes
{
    public class MttRoutes
    {
        #region Mtts

        public const string CreateMttMethod = "POST";
        public const string CreateMttsRouteName = "create_mtt";
        public const string CreateMttsRouteUrl = "/mtts";

        public const string EditMttsMethod = "PUT";
        public const string EditMttsRouteName = "update_mtts_by_id";
        public const string EditMttsRouteUrl = "/mtts/{id}";

        public const string ViewMttsMethod = "GET";
        public const string ViewMttsRouteName = "get_mtt_by_id";
        public const string ViewMttsRouteUrl = "/mtts/{id}";

        public const string AllMttsRouteNameMethod = "GET";
        public const string AllMttsRouteName = "mtts";
        public const string AllMttsRouteUrl = "/mtts";


        public const string DeleteMttsMethod = "DELETE";
        public const string DeleteMttsRouteName = "delete_mtt_by_id";
        public const string DeleteMttsRouteUrl = "/mtts/{id}";
        #endregion Mtts
    }
}
