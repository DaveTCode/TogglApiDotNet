using System;

namespace TogglApi.Client.Reports.Models.Request
{
    public enum CalculateOptions
    {
        Time,
        Earnings
    }

    public static class CalculateOptionsExtensions
    {
        public static string UrlRepresentation(this CalculateOptions options)
        {
            return Enum.GetName(typeof(CalculateOptions), options).ToLowerInvariant();
        }
    }
}
