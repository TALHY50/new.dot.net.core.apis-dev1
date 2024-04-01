using SharedLibrary.Models;

namespace SharedLibrary.Utilities;

public static class Clocker
{
    private static readonly DateTimeOffset UnixEpoch =
        new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);

    public static long ToUnixTimeMicroseconds(this DateTimeOffset timestamp)
    {
        TimeSpan duration = timestamp - UnixEpoch;
        return duration.Ticks / 10;
    }

    public static DateTime Now()
    {
        DateTime currentDateTime = DateTime.UtcNow;

        return currentDateTime;
    }
    public static string GetSystemDateTime(string format = "yyyy-MM-dd HH:mm:ss")
    {
        var utcNow = DateTime.UtcNow;
        return utcNow.ToString(format);
    }

    
    public static DateTime StartOfTheDay(DateTime dateTime)
    {
        return dateTime.Date;
        
    }
    public static DateTime EndOfTheDay(DateTime dateTime)
    {
        return dateTime.Date.AddDays(1).AddTicks(-1);
    }


    public static DateTime NextWeekDay(DateTime dateTime, DayOfWeek weekDay)
    {
        DateTime now = dateTime.Date;
        int offset = CalculateOffset(now.DayOfWeek, weekDay);
        DateTime nextWeekDay = now.AddDays(offset);

        return nextWeekDay;
    }

     public static DateTime NextWeekDay(DateTime dateTime,string weekDay)
    {
        DayOfWeek dayOfWeek = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), weekDay);

        return NextWeekDay(dateTime, dayOfWeek);
        
    }
    
    
    public static int CalculateOffset(DayOfWeek current, DayOfWeek desired) {
        int c = (int)current;
        int d = (int)desired;
        int offset = (7 - c + d) % 7;
        return offset == 0 ? 7 : offset;
    }
    
        
    public static DateTime NextMonthlyDate(DateTime dateTime, int dayOfMonth)
    {
        
        DateTime desiredDate = new DateTime(dateTime.Year, dateTime.Month, dayOfMonth);

        // If the desired date is before or equal to the current date, add one month
        if (desiredDate <= dateTime)
        {
            desiredDate = desiredDate.AddMonths(1);
        }

        return desiredDate;
    }
    
    
    public static int DaysInMonth(DateTime dateTime)
    {
        int year = dateTime.Year;
        int month = dateTime.Month;

        return DateTime.DaysInMonth(year, month);
    }
    
    public static bool IsWeekend(DateTime dateTime)
    {
        // Check if the day of the week is Saturday or Sunday
        return dateTime.DayOfWeek == DayOfWeek.Saturday || dateTime.DayOfWeek == DayOfWeek.Sunday;
    }
    
    public static bool IsInRange(DateTime dateToCheck, DateTime startDate, DateTime endDate)
    {
        return dateToCheck >= startDate && dateToCheck <= endDate;
    }

    public static bool IsHoliday(List<HolidaySetting> holidays, DateTime dateTime)
    {
        foreach (var holiday in holidays)
        {
            var beginning = Clocker.StartOfTheDay(holiday.BeginDate);
            var ending = Clocker.EndOfTheDay(holiday.EndDate);
            if (Clocker.IsInRange(dateTime, beginning, ending))
            {
                return true;
            }
            
        }

        return false;
    }

    public static int DateMonthYear(DateTime dateTime)
    {
        int day = dateTime.Day;
        int month = dateTime.Month;
        int year = dateTime.Year;


        int dateMonthYear = (day * 1000000) + (month * 10000) + year;

        return dateMonthYear;
    }


    public static int YearMonthDate(DateTime dateTime)
    {
        int year = dateTime.Year;
        int month = dateTime.Month;
        int day = dateTime.Day;

        return year * 10000 + month * 100 + day;
    }


    public static bool IsSameDay(DateTime? dateTime)
    {
        if (dateTime == null)
        {
            return false;
        }
        
        return dateTime.Value.Date == DateTime.Today.Date;

    }
}
