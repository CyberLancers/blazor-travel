namespace BlazorAssemblyTravel.Shared;

public static class DateUtils
{
    public static List<DateTime> CreateDateList(DateTime startDate, int numberOfItems)
    {
        var dateList = new List<DateTime> { startDate };
        var currentDate = startDate;
        for (var i = 1; i < numberOfItems; i++)
        {
            currentDate = currentDate.AddMonths(1);
            dateList.Add(currentDate);
        }

        return dateList;
    }
    
    public static DateTime GetStartOfMonth(DateTime date)
    {
        return new DateTime(date.Year, date.Month, 1);
    }

    public static DateTime GetEndOfMonth(DateTime date)
    {
        return new DateTime(date.Year, date.Month, 1).AddMonths(1).AddDays(-1);
    }
}