namespace SharedBusiness.Main.Common.Contracts;

public record BusinessHoursAndWeekendDto(
    uint id, byte HourType, uint? CountryId,
    string Day, sbyte IsWeekend, string Gmt, DateTime OpenAt, DateTime CloseAt, uint? CompanyId, byte Status
    );