using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMT.Thunes.Response.Account
{
    public class ListReportFilesAvailableResponse
    {
        public int id { get; set; }
        public string report_type { get; set; }
        public string file_type { get; set; }
        public string name { get; set; }
    }
}