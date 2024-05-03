using ACL.Database;
using ACL.Interfaces;
using ACL.Requests.CustomDataAnotator;
using SharedLibrary.CustomDataAnotator;
using System.Numerics;

namespace ACL.Requests.V1
{
    public class AclModuleRequest
    {
        //[UniqueValue("AclModules", "Id", ErrorMessage = "Id must be unique.")]
        [UniqueValue<ApplicationDbContext,ICustomUnitOfWork>("AclModule", "Id", ErrorMessage = "Id must be unique.")]
        public ulong Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int Sequence { get; set; }
        public string DisplayName { get; set; }
    }
}
