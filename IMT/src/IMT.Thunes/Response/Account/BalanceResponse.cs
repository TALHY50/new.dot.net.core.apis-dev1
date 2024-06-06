using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMT.Thunes.Response.Account
{
    public class BalanceResponse
    {
        public int id { get; set; }
        public string currency { get; set; }
        public int balance { get; set; }
        public int pending { get; set; }
        public int available { get; set; }
        public int credit_facility { get; set; }
    }
}