namespace Admin.App.Presentation.Routes
{
    public class TransactionTypeRoutes
    {
        public const string GetTransactionTypeMethod = "GET";
        public const string GetTransactionTypeName = "transactionTypes";
        public const string GetTransactionTypeTemplate = "/transactionTypes";

        public const string GetTransactionTypeByIdMethod = "GET";
        public const string GetTransactionTypeByIdName = "get_transactionType_by_id";
        public const string GetTransactionTypeByIdTemplate = "/transactionTypes/{id}";

        public const string CreateTransactionTypeMethod = "POST";
        public const string CreateTransactionTypeName = "create_transactionType";
        public const string CreateTransactionTypeTemplate = "/transactionTypes";

        public const string DeleteTransactionTypeMethod = "DELETE";
        public const string DeleteTransactionTypeName = "delete_transactionType_by_id";
        public const string DeleteTransactionTypeTemplate = "/transactionTypes/{id}";

        public const string UpdateTransactionTypeMethod = "PUT";
        public const string UpdateTransactionTypeName = "update_transactionType_by_id";
        public const string UpdateTransactionTypeTemplate = "/transactionTypes/{id}";
    }
}
