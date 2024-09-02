using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedBusiness.Main.Common.Contracts
{
    public record ServiceMethodDto
    (
        uint id,
        byte method,
        uint? company_id
    );
}
