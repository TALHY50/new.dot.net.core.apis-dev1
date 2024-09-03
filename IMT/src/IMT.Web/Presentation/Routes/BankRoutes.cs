namespace IMT.App.Presentation.Routes
{
    public class BankRoutes
    {
        public const string GetBankMethod = "GET";
        public const string GetBankName = "banks";
        public const string GetBankTemplate = "/v1/money-transfer/banks";

        public const string GetBankByIdMethod = "GET";
        public const string GetBankByIdName = "get_bank_by_id";
        public const string GetBankByIdTemplate = "/v1/money-transfer/banks/{id}";

        public const string CreateBankMethod = "POST";
        public const string CreateBankName = "create_bank";
        public const string CreateBankTemplate = "/v1/money-transfer/banks";

        public const string DeleteBankMethod = "DELETE";
        public const string DeleteBankName = "delete_bank_by_id";
        public const string DeleteBankTemplate = "/v1/money-transfer/banks/{id}";

        public const string UpdateBankMethod = "PUT";
        public const string UpdateBankName = "update_bank_by_id";
        public const string UpdateBankTemplate = "/v1/money-transfer/banks/{id}";
    }
}
