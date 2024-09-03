namespace Admin.App.Presentation.Routes;

public class TransactionLimitRoutes
{
    public const string GetTransactionLimitMethod = "GET";
    public const string GetTransactionLimitName = "transactionlimits";
    public const string GetTransactionLimitTemplate = "/transactionlimits";
    
    public const string GetTransactionLimitByIdMethod = "GET";
    public const string GetTransactionLimitByIdName = "get_transactionlimit_by_id";
    public const string GetTransactionLimitByIdTemplate = "/transactionlimits/{id}";
    
    public const string CreateTransactionLimitMethod = "POST";
    public const string CreateTransactionLimitName = "create_transactionlimit";
    public const string CreateTransactionLimitTemplate = "/transactionlimits";
    
    public const string DeleteTransactionLimitMethod = "DELETE";
    public const string DeleteTransactionLimitName = "delete_transactionlimit_by_id";
    public const string DeleteTransactionLimitTemplate = "/transactionlimits/{id}";
    
    public const string UpdateTransactionLimitMethod = "PUT";
    public const string UpdateTransactionLimitName = "update_transactionlimit_by_id";
    public const string UpdateTransactionLimitTemplate = "/transactionlimits/{id}";
    
}