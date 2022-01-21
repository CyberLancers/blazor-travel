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
}