using SharedKernel.Main.Application.Enums;

namespace SharedBusiness.Main.Common.Contracts
{
    public record MttPaymentSpeedDto(
        uint id,
        uint mtt_id,
        uint processing_time,
        string gmt,
        DateTime opens_at,
        DateTime closes_at,
        string working_days,
        bool is_processing_during_banking_holiday,
        uint? company_id,
        StatusValues status
        );
}
