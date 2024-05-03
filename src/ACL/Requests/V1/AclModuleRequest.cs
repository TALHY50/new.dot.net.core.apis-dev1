using ACL.Database;
using ACL.Interfaces;
using ACL.Requests.CustomDataAnotator;
using SharedLibrary.CustomDataAnotator;
using System.ComponentModel;
using System.Numerics;

namespace ACL.Requests.V1
{
    public class AclModuleRequest
    {

        [DefaultValue("1004")]
        //[UniqueValue("AclModules", "Id", ErrorMessage = "Id must be unique.")]
        [UniqueValue<ApplicationDbContext, ICustomUnitOfWork>("AclModule", "Id", ErrorMessage = "Id must be unique.")]
        public ulong id { get; set; }

        [DefaultValue("Hrm Module")]
        public string name { get; set; }

        [DefaultValue("<i class='fa fa-list-ul'></i>")]
        public string icon { get; set; }

        [DefaultValue(1)]
        public int sequence { get; set; }

        [DefaultValue("Hrm Module")]
        public string display_name { get; set; }
    }
}
