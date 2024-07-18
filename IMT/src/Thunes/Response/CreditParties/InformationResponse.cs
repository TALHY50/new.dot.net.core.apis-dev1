using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMT.Thunes.Response.CreditParties.Common;
using IMT.Thunes.Response.Transfer.Transaction;
using Beneficiary = IMT.Thunes.Response.CreditParties.Common.Beneficiary;

namespace IMT.Thunes.Response.CreditParties
{
    public class InformationResponse
    {
        public Beneficiary beneficiary { get; set; }
        public int id { get; set; }
    }
}