namespace Admin.Web.Presentation.Routes;

public class TransactionLimitRoutes
{
    public const string GetTransactionLimitMethod = "GET";
    public const string GetTransactionLimitName = "transaction-limits";
    public const string GetTransactionLimitTemplate = "/transaction-limits";
    
    public const string GetTransactionLimitByIdMethod = "GET";
    public const string GetTransactionLimitByIdName = "get_transaction-limit_by_id";
    public const string GetTransactionLimitByIdTemplate = "/transaction-limits/{id}";
    
    public const string CreateTransactionLimitMethod = "POST";
    public const string CreateTransactionLimitName = "create_transaction-limit";
    public const string CreateTransactionLimitTemplate = "/transaction-limits";
    
    public const string DeleteTransactionLimitMethod = "DELETE";
    public const string DeleteTransactionLimitName = "delete_transaction-limit_by_id";
    public const string DeleteTransactionLimitTemplate = "/transaction-limits/{id}";
    
    public const string UpdateTransactionLimitMethod = "PUT";
    public const string UpdateTransactionLimitName = "update_transaction-limit_by_id";
    public const string UpdateTransactionLimitTemplate = "/transaction-limits/{id}";
    
}