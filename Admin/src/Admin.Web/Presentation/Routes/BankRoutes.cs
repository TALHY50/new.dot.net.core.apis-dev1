namespace Admin.App.Presentation.Routes
{
    public class BankRoutes
    {
        public const string GetBankMethod = "GET";
        public const string GetBankName = "banks";
        public const string GetBankTemplate = "/banks";

        public const string GetBankByIdMethod = "GET";
        public const string GetBankByIdName = "get_bank_by_id";
        public const string GetBankByIdTemplate = "/banks/{id}";

        public const string CreateBankMethod = "POST";
        public const string CreateBankName = "create_bank";
        public const string CreateBankTemplate = "/banks";

        public const string DeleteBankMethod = "DELETE";
        public const string DeleteBankName = "delete_bank_by_id";
        public const string DeleteBankTemplate = "/banks/{id}";

        public const string UpdateBankMethod = "PUT";
        public const string UpdateBankName = "update_bank_by_id";
        public const string UpdateBankTemplate = "/banks/{id}";
    }
}
