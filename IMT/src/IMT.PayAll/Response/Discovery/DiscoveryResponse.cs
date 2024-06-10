using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMT.PayAll.Response.Discovery
{
    public class DiscoveryResponse
    {
        public Dob? dob { get; set; }
        public RegistrationAddress registration_address { get; set; }
    }

    #region SubOrdinate Classes
    public class City
    {
        public string mask { get; set; }
        public string title { get; set; }
        public string data_type { get; set; }
        public int max_length { get; set; }
        public int min_length { get; set; }
    }

    public class Country
    {
        public string title { get; set; }
        public string data_type { get; set; }
    }

    public class Dob
    {
        public string title { get; set; }
        public string data_type { get; set; }
    }

    public class RegistrationAddress
    {
        public City city { get; set; }
        public Street street { get; set; }
        public Country country { get; set; }
    }

    public class Street
    {
        public string mask { get; set; }
        public string title { get; set; }
        public string data_type { get; set; }
        public int max_length { get; set; }
        public int min_length { get; set; }
    }
    

    #endregion
}
