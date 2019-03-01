using System;

namespace TogglApi.Client.Reports.Models.Request
{
    /// <summary>
    /// Choice of the report types which are available over the API
    /// </summary>
    public enum ReportType
    {
        Weekly,
        Summary,
        Detailed
    }

    public static class ReportTypeExtensions
    {
        internal static string UrlRepresentation(this ReportType reportType)
        {
            switch (reportType)
            {
                case ReportType.Weekly:
                    return "weekly";
                case ReportType.Summary:
                    return "summary";
                case ReportType.Detailed:
                    return "details";
                default:
                    throw new ArgumentOutOfRangeException(nameof(reportType), reportType, null);
            }
        }
    }
}