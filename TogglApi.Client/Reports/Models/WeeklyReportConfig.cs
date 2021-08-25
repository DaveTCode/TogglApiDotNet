using System;
using System.Collections.Generic;
using System.Reflection;
using TogglApi.Client.Reports.Models.Request;
using TogglApi.Client.Reports.Models.Response;

namespace TogglApi.Client.Reports.Models
{
    /// <summary>
    /// Refers to https://github.com/toggl/toggl_api_docs/blob/master/reports/weekly.md
    /// </summary>
    public class WeeklyReportConfig<T> : ReportConfig
        where T : WeeklyReportResponseGroup
    {
        public WeeklyReportConfig(string userAgent, long workspaceId, DateTime? since = null,
            BillableOptions? billableOptions = null, IList<int> clientIds = null, IList<int> projectIds = null,
            IList<int> userIds = null, IList<int> memberOfGroupIds = null, IList<int> orMemberOfGroupIds = null,
            IList<int> tagIds = null, IList<int> taskIds = null, IList<int> timeEntryIds = null,
            string description = null, bool withoutDescription = false, WeeklyOrderField? orderField = null,
            bool orderDescending = false, bool distinctRates = false, bool rounding = false,
            DisplayHours? displayHours = null, CalculateOptions calculateOptions = CalculateOptions.Time)
            : base(ReportType.Weekly, userAgent, workspaceId, since, null, billableOptions, clientIds, projectIds,
                userIds, memberOfGroupIds, orMemberOfGroupIds, tagIds, taskIds, timeEntryIds, description,
                withoutDescription, orderField?.UrlRepresentation(), orderDescending, distinctRates, rounding,
                displayHours)
        {
            if (typeof(T).GetCustomAttribute(typeof(ToggleApiUrlValueAttribute)) is ToggleApiUrlValueAttribute
                groupingAttribute)
            {
                UrlParameters.Add("grouping", groupingAttribute.UrlValue);
            }

            UrlParameters.Add("calculate", calculateOptions.UrlRepresentation());
        }
    }
}
