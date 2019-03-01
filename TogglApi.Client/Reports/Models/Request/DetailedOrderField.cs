using System;

namespace TogglApi.Client.Reports.Models.Request
{
    /// <summary>
    /// Used to determine ordering on the detailed report request
    /// </summary>
    public enum DetailedOrderField
    {
        Date,
        Description,
        Duration,
        User
    }

    public static class DetailedOrderFieldExtensions
    {
        public static string UrlRepresentation(this DetailedOrderField detailedOrderField)
        {
            switch (detailedOrderField)
            {
                case DetailedOrderField.Date:
                case DetailedOrderField.Description:
                case DetailedOrderField.Duration:
                case DetailedOrderField.User:
                    return Enum.GetName(typeof(DetailedOrderField), detailedOrderField).ToLowerInvariant();
                default:
                    throw new ArgumentOutOfRangeException(nameof(detailedOrderField), detailedOrderField, null);
            }
        }
    }
}
