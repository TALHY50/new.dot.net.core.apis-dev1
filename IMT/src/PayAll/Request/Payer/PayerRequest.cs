namespace PayAll.Request.Payer
{
    public class PayerRequest : BasePayerRequest
    {

        public string first_name { get; set; }

        public string middle_name { get; set; }

        public string last_name { get; set; }


        public string phone_number { get; set; }

        public string nationality { get; set; }

        public string government_id { get; set; }

        public DateOnly date_of_birth { get; set; }
        public string source_of_income { get; set; }
        public string place_of_birth { get; set; }
        public string occupation { get; set; }
        public string relationship_with_beneficiary { get; set; }

        public string legal_name { get; set; }
        public string trade_name { get; set; }
       
        public string country { get; set; }
       
        public string registration_number { get; set; }

        public DateOnly registration_date { get; set; }


    }
}
