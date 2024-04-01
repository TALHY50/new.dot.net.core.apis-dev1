using static SharedLibrary.Constants.Constants;

namespace SharedLibrary.Models;

public partial class TransactionState
{
    public uint Id { get; set; }

    public string Name { get; set; } = null!;

    public string? NameTr { get; set; }

    public string? JsonData { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
    public const int COMPLETED = 1;
    public const int REJECTED = 2;
    public const int PENDING = 3;
    public const int STANDBY = 4;
    public const int REFUNDED = 5;
    public const int AWAITING = 6;
    public const int AWAITINGREFUND = 7;
    public const int PROVISION = 30;
    public const int CHARGE_BACK_REQUESTED = 8;
    public const int CHARGE_BACK_APPROVED = 9;
    public const int CHARGE_BACK_REJECTED = 10;
    public const int CHARGE_BACKED = 11;
    public const int CHARGE_CANCELED = 12;
    public const int PARTIAL_REFUND = 13;
    public const int FAILED = 14;
    public const int CANCELED = 15;
    public const int PREAUTH_PENDING = 16;
    public const int RETRY_AWAITING_REFUND = 17;

    public static readonly int[] CHARGEBACK_TRANSACTION_STATES = new int[]
    {
        CHARGE_BACK_REQUESTED, CHARGE_BACK_APPROVED, CHARGE_BACK_REJECTED, CHARGE_BACKED, CHARGE_CANCELED
    };

    public static int[] GetSuccessStates()
    {
        return new int[]
        {
            COMPLETED,
            REFUNDED,
            PARTIAL_REFUND,
            CHARGE_BACKED,
            CHARGE_BACK_REQUESTED,
            CHARGE_BACK_REJECTED,
            CHARGE_CANCELED,
            CHARGE_BACK_APPROVED
        };
    }

    public static string Status(int status_id, int sale_type = Sale.Auth)
    {
        string new_status = "";
        if (status_id == 1)
        {
            new_status = "Completed";
        }
        else if (status_id == 2)
        {
            new_status = "Rejected";
        }
        else if (status_id == 3)
        {
            new_status = "Pending";
            if (sale_type == Sale.PREAUTH)
            {
                new_status = Constants.Constants.PRE_AUTHORIZATION;
            }
        }
        else if (status_id == 4)
        {
            new_status = "Stand By";
        }
        else if (status_id == 5)
        {
            new_status = "Refunded";
        }
        else if (status_id == 6)
        {
            new_status = "Awaiting";
        }
        else if (status_id == 7)
        {
            new_status = "Awaiting Refund";
        }
        else if (status_id == 8)
        {
            new_status = "Chargeback Requested";
        }
        else if (status_id == 9)
        {
            new_status = "Chargeback Approved";
        }
        else if (status_id == 10)
        {
            new_status = "Chargeback Rejected";
        }
        else if (status_id == 11)
        {
            new_status = "Chargebacked";
        }
        else if (status_id == 12)
        {
            new_status = "Chargeback Cancelled";
        }
        else if (status_id == 13)
        {
            new_status = "Partial Refund";
        }
        else if (status_id == 14)
        {
            new_status = "Failed";
        }
        else if (status_id == 15)
        {
            new_status = "Canceled";
        }
        else if (status_id == 16)
        {
            new_status = "PreAuth  Pending";
        }
        else if (status_id == 17)
        {
            new_status = "Retry Awaiting Refund";
        }

        return new_status;
    }
}
