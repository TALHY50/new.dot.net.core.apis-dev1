namespace Admin.Web.Presentation.Routes
{
    public class TransactionTypeRoutes
    {
        public const string GetTransactionTypeMethod = "GET";
        public const string GetTransactionTypeName = "transaction-types";
        public const string GetTransactionTypeTemplate = "/transaction-types";

        public const string GetTransactionTypeByIdMethod = "GET";
        public const string GetTransactionTypeByIdName = "get-transaction-type-by-id";
        public const string GetTransactionTypeByIdTemplate = "/transaction-types/{id}";

        public const string CreateTransactionTypeMethod = "POST";
        public const string CreateTransactionTypeName = "create-transaction-type";
        public const string CreateTransactionTypeTemplate = "/transaction-types";

        public const string DeleteTransactionTypeMethod = "DELETE";
        public const string DeleteTransactionTypeName = "delete_transaction-type-by-id";
        public const string DeleteTransactionTypeTemplate = "/transaction-types/{id}";

        public const string UpdateTransactionTypeMethod = "PUT";
        public const string UpdateTransactionTypeName = "update_transaction-type-by-id";
        public const string UpdateTransactionTypeTemplate = "/transaction-types/{id}";
    }
}
