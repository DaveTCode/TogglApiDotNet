using System;

namespace TogglApi.Client.Reports.Models.Request
{
    public enum DisplayHours
    {
        Decimal,
        Minutes
    }

    public static class DisplayHoursExtensions
    {
        public static string UrlRepresentation(this DisplayHours displayHours)
        {
            return Enum.GetName(typeof(DisplayHours), displayHours).ToLowerInvariant();
        }
    }
}
