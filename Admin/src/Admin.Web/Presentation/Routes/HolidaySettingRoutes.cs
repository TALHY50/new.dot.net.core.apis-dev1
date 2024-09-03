namespace Admin.App.Presentation.Routes;

public class HolidaySettingRoutes
{
    public const string GetHolidaySettingMethod = "GET";
    public const string GetHolidaySettingName = "holiday_settings";
    public const string GetHolidaySettingTemplate = "/holiday-settings";

    public const string GetHolidaySettingByIdMethod = "GET";
    public const string GetHolidaySettingByIdName = "get_holiday_setting_by_id";
    public const string GetHolidaySettingByIdTemplate = "/holiday-settings/{id}";

    public const string CreateHolidaySettingMethod = "POST";
    public const string CreateHolidaySettingName = "create_holiday_setting";
    public const string CreateHolidaySettingTemplate = "/holiday-settings";

    public const string DeleteHolidaySettingMethod = "DELETE";
    public const string DeleteHolidaySettingName = "delete_holiday_setting_by_id";
    public const string DeleteHolidaySettingTemplate = "/holiday-settings/{id}";

    public const string UpdateHolidaySettingMethod = "PUT";
    public const string UpdateHolidaySettingName = "update_holiday_setting_by_id";
    public const string UpdateHolidaySettingTemplate = "/holiday-settings/{id}";
}
