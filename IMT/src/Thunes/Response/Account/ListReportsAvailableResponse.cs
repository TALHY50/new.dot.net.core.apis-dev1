namespace Thunes.Response.Account
{
    public class ListReportsAvailableResponse
    {
        public int id { get; set; }
        public string type { get; set; }
        public string timezone { get; set; }
        public string cut_off_time { get; set; }
        public string report_date { get; set; }
        public DateTime period_start { get; set; }
        public DateTime period_end { get; set; }
        public List<File> files { get; set; }
    }

    public class File
    {
        public int id { get; set; }
        public string report_type { get; set; }
        public string file_type { get; set; }
        public string name { get; set; }
    }
}