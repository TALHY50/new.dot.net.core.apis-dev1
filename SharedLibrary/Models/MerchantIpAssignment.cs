namespace SharedLibrary.Models;

public partial class MerchantIpAssignment
{
    public const int SALE_IP_RESTICTION = 1;
    public const int CASHOUT_IP_RESTICTION = 2;
    public const int WALLET_SERVICE = 3;
    public const int IP_BLOCK_TYPE_WHITELIST = 1;
    public const int IP_SOURCE_TYPE_USER = 2;
    public const int IP_BLOCK_TYPE_BLACKLIST = 2;
    
    
    public ulong Id { get; set; }

    public int MerchantId { get; set; }

    public string AssignedIp { get; set; } = null!;

    /// <summary>
    /// Sale =&gt; 1 , Cashout =&gt; 2, 3 = Wallet UnitOfWork
    /// </summary>
    public sbyte Type { get; set; }

    public int? Limit { get; set; }

    public DateOnly? ValidateDate { get; set; }

    public int TransactionCount { get; set; }
    
    public sbyte IpBlockType { get; set;}
    
    public sbyte IpSourceType { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

}
