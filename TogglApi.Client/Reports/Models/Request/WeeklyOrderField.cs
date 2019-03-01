using System;

namespace TogglApi.Client.Reports.Models.Request
{
    /// <summary>
    /// Specify the sort order on a weekly report
    /// </summary>
    public enum WeeklyOrderField
    {
        Title,
        Day1,
        Day2,
        Day3,
        Day4,
        Day5,
        Day6,
        Day7,
        WeekTotal
    }

    public static class WeeklyOrderFieldExtensions
    {
        internal static string UrlRepresentation(this WeeklyOrderField weeklyOrderField)
        {
            switch (weeklyOrderField)
            {
                case WeeklyOrderField.Title:
                case WeeklyOrderField.Day1:
                case WeeklyOrderField.Day2:
                case WeeklyOrderField.Day3:
                case WeeklyOrderField.Day4:
                case WeeklyOrderField.Day5:
                case WeeklyOrderField.Day6:
                case WeeklyOrderField.Day7:
                    return Enum.GetName(typeof(WeeklyOrderField), weeklyOrderField).ToLowerInvariant();
                case WeeklyOrderField.WeekTotal:
                    return "week_total";
                default:
                    throw new ArgumentOutOfRangeException(nameof(weeklyOrderField), weeklyOrderField, null);
            }
        }
    }
}
