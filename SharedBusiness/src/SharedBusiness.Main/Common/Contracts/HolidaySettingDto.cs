
using SharedKernel.Main.Application.Enums;

namespace SharedBusiness.Main.Common.Contracts;

public record class HolidaySettingDto
(
    uint id, uint? country_id, DateTime date, HolidaySettingTypeValues type, string gmt, DateTime? open_at, DateTime? close_at, uint? company_id, HolidaySettingStatusValues status
);
