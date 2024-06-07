using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMT.Thunes.Response.Discovery.Common
{
    public class CreditPartyVerification
    {
        public List<List<string>> credit_party_identifiers_accepted { get; set; }
        public List<List<string>> required_receiving_entity_fields { get; set; }
    }
}