using System;

namespace TogglApi.Client.Reports.Models.Request
{
    public enum BillableOptions
    {
        Yes,
        No,
        Both
    }

    public static class BillableOptionExtensions
    {
        public static string UrlRepresentation(this BillableOptions billableOptions)
        {
            switch (billableOptions)
            {
                case BillableOptions.Yes:
                    return "yes";
                case BillableOptions.No:
                    return "no";
                case BillableOptions.Both:
                    return "both";
                default:
                    throw new ArgumentOutOfRangeException(nameof(billableOptions), billableOptions, null);
            }
        }
    }
}
