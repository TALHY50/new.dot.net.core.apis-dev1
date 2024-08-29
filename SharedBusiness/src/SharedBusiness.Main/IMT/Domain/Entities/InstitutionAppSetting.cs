using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedBusiness.Main.IMT.Domain.Entities
{
    public class InstitutionAppSetting
    {
        public uint Id { get; set; }
        public uint InstitutionId { get; set; }
        public string? AppName { get; set; }
        public string? AppId { get; set; }
        public string? AppSecret { get; set; }
        public string? Token { get; set; }
        public byte Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? ExpiredAt { get; set; }
        public uint? CreatedById { get; set; }
        public DateTime? UpdatedById { get; set; }
    }
}
