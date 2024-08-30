using System.ComponentModel;

namespace ACL.Bussiness.Contracts.Requests
{
    public class AclModuleRequest
    {

        [DefaultValue("1004")]
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
