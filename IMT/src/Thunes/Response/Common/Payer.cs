namespace Thunes.Response.Common
{
    public class Payer
    {
        public int id { get; set; }
        public string name { get; set; }
        public string currency { get; set; }
        public string country_iso_code { get; set; }
        public Service service { get; set; }
    }
}