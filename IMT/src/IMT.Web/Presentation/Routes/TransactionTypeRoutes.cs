namespace IMT.App.Presentation.Routes
{
    public class TransactionTypeRoutes
    {
        public const string GetTransactionTypeMethod = "GET";
        public const string GetTransactionTypeName = "transaction-types";
        public const string GetTransactionTypeTemplate = "/v1/money-transfer/transaction-types";

        public const string GetTransactionTypeByIdMethod = "GET";
        public const string GetTransactionTypeByIdName = "get_transaction-type_by_id";
        public const string GetTransactionTypeByIdTemplate = "/v1/money-transfer/transaction-types/{id}";

        public const string CreateTransactionTypeMethod = "POST";
        public const string CreateTransactionTypeName = "create_transaction-type";
        public const string CreateTransactionTypeTemplate = "/v1/money-transfer/transaction-types";

        public const string DeleteTransactionTypeMethod = "DELETE";
        public const string DeleteTransactionTypeName = "delete_transaction-type_by_id";
        public const string DeleteTransactionTypeTemplate = "/v1/money-transfer/transaction-types/{id}";

        public const string UpdateTransactionTypeMethod = "PUT";
        public const string UpdateTransactionTypeName = "update_transaction-type_by_id";
        public const string UpdateTransactionTypeTemplate = "/v1/money-transfer/transaction-types/{id}";
    }
}
