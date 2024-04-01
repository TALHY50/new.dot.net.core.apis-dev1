using SharedLibrary.Interfaces;
using SharedLibrary.Interfaces.Repositories;
using SharedLibrary.Models;
using SharedLibrary.Utilities;

namespace SharedLibrary.Repositories;

public class HolidaySettingRepository : GenericRepository<HolidaySetting>, IHolidaySettingRepository
{
    private IUnitOfWork _unitOfWork;
    private List<HolidaySetting> _holidaySettings;

    public HolidaySettingRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _unitOfWork = unitOfWork;

    }


    public DateTime IsHoliday()
    {
        var v = new DateTime();
        return new DateTime();
        
    }

    
    public DateTime AdJustDateForHolidaysAndWeekends(DateTime dateTime)
    {
        if (_holidaySettings == null || _holidaySettings.Count == 0)
        {
            _holidaySettings = this.GetHolidayDates(dateTime);
            
        }

        while (Clocker.IsWeekend(dateTime) || Clocker.IsHoliday(_holidaySettings, dateTime))
        {
            dateTime = dateTime.AddDays(1);
        }
        
        return dateTime;

    }

public List<HolidaySetting> GetHolidayDates(DateTime dateTime)
{
    var holidaySettings = _unitOfWork.ApplicationDbContext.HolidaySettings
        .Where(x => (x.BeginDate >= dateTime || x.EndDate >= dateTime))
        .Select(x => new HolidaySetting{BeginDate = x.BeginDate, EndDate = x.EndDate})
        .ToList();

    return holidaySettings;
}
}