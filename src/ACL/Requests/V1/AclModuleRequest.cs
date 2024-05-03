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
        public ulong Id { get; set; }

        [DefaultValue("Hrm Module")]
        public string Name { get; set; }

        [DefaultValue("<i class='fa fa-list-ul'></i>")]
        public string Icon { get; set; }

        [DefaultValue(1)]
        public int Sequence { get; set; }

        [DefaultValue("Hrm Module")]
        public string DisplayName { get; set; }
    }
}
