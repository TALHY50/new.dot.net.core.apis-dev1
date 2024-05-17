using System.ComponentModel;
using ACL.Application.Interfaces;
using ACL.Contracts.Requests.CustomDataAnotator;
using ACL.Infrastructure.Database;
using SharedLibrary.CustomDataAnotator;

namespace ACL.Contracts.Requests.V1
{
    public class AclModuleRequest
    {

        [DefaultValue("1004")]
        [ModuleIdUnique]
        public ulong Id { get; set; }

        [DefaultValue("Hrm Module")]
        [ModuleNameUnique]
        public string Name { get; set; }

        [DefaultValue("<i class='fa fa-list-ul'></i>")]
        public string Icon { get; set; }

        [DefaultValue(1)]
        public int Sequence { get; set; }

        [DefaultValue("Hrm Module")]
        public string DisplayName { get; set; }
    }
}
