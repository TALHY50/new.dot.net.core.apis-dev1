using SharedLibrary.Models;

namespace SharedLibrary.Interfaces.Repositories;

public interface IHolidaySettingRepository : IGenericRepository<HolidaySetting>
{

 public DateTime AdJustDateForHolidaysAndWeekends(DateTime dateTime);

 public List<HolidaySetting> GetHolidayDates(DateTime dateTime);

}