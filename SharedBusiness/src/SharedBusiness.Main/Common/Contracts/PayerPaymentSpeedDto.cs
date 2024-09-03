using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedBusiness.Main.Common.Contracts
{
    public record PayerPaymentSpeedDto
    (
        uint id,
        uint payer_id,
        uint processing_time,
        string gmt,
        string working_days,
        bool is_processing_during_banking_holiday,
        uint? company_id
    );
}
