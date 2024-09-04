using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACL.Business.Contracts.Responses
{
    public record RoleDto(
        uint id,
        string? name,
        string? title
        );
}
