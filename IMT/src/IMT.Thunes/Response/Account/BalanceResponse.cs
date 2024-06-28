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
        public decimal balance { get; set; }
        public int pending { get; set; }
        public decimal available { get; set; }
        public int credit_facility { get; set; }
        public string name {  get; set; }
    }
}