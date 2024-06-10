using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMT.PayAll.Response.Payer
{
    public class PayersResponse
    {
        public Guid id { get; set; }
        public List<AccountResponse> accounts { get; set; }
        public string type { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public string phone_number { get; set; }
        public RegistrationAddressResponse registration_address { get; set; }
        public string nationality { get; set; }
        public string government_id { get; set; }
        public string date_of_birth { get; set; }
        public string source_of_income { get; set; }
        public string email { get; set; }
        public string place_of_birth { get; set; }
        public string occupation { get; set; }
        public string relationship_with_beneficiary { get; set; }
        public string legal_name { get; set; }
        public string trade_name { get; set; }
        public string country { get; set; }
        public string registration_number { get; set; }
        public string registration_date { get; set; }
    }
}
