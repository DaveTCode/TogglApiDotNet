using System;

namespace TogglApi.Client.Reports.Models.Request
{
    /// <summary>
    /// USed to determine ordering on the summary report type
    /// </summary>
    public enum SummaryOrderField
    {
        Title,
        Duration,
        Amount
    }

    public static class SummaryOrderFieldExtensions
    {
        internal static string UrlRepresentation(this SummaryOrderField summaryOrderField)
        {
            switch (summaryOrderField)
            {
                case SummaryOrderField.Title:
                case SummaryOrderField.Duration:
                case SummaryOrderField.Amount:
                    return Enum.GetName(typeof(SummaryOrderField), summaryOrderField).ToLowerInvariant();
                default:
                    throw new ArgumentOutOfRangeException(nameof(summaryOrderField), summaryOrderField, null);
            }
        }
    }
}
