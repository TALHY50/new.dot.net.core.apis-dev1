using SharedKernel.Main.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedBusiness.Main.Admin.Contracts.Contracts.Responses;

public record MttDto(
    uint id,
    uint? corridor_id,
    uint? currency_id,
    uint payer_id,
    uint? service_method_id,
    uint? transaction_type_id,
    decimal cot_percentage,
    decimal cot_fixed,
    decimal fx_spread,
    decimal mark_up_percentage,
    decimal mark_up_fixed,
    decimal increment,
    byte money_precision,
    uint company_id,
    StatusValues status
    );