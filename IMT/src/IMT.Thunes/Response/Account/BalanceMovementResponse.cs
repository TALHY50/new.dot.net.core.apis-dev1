using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMT.Thunes.Response.Balances
{
    public class BalanceMovementResponse
    {
        public int balance_operation_number { get; set; }
        public DateTime creation_date { get; set; }
        public string movement_type { get; set; }
        public double amount { get; set; }
        public string currency { get; set; }
        public int transaction_reference_id { get; set; }
        public string operation { get; set; }
        public double balance { get; set; }
        public double pending_balance { get; set; }
    }
}