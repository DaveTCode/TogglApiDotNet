using System;
using System.Collections.Generic;
using TogglApi.Client.Reports.Models.Request;

namespace TogglApi.Client.Reports.Models
{
    /// <summary>
    /// Refers to https://github.com/toggl/toggl_api_docs/blob/master/reports/detailed.md
    /// </summary>
    public class DetailedReportConfig : ReportConfig
    {
        public DetailedReportConfig(string userAgent, int workspaceId, DateTime? since = null,
            DateTime? until = null, BillableOptions? billableOptions = null, IList<int> clientIds = null,
            IList<int> projectIds = null, IList<int> userIds = null, IList<int> memberOfGroupIds = null,
            IList<int> orMemberOfGroupIds = null, IList<int> tagIds = null, IList<int> taskIds = null,
            IList<int> timeEntryIds = null, string description = null, bool withoutDescription = false,
            DetailedOrderField? orderField = null, bool orderDescending = false, bool distinctRates = false, bool rounding = false,
            DisplayHours? displayHours = null) : base(ReportType.Detailed, userAgent, workspaceId, since, until, billableOptions, clientIds,
            projectIds, userIds, memberOfGroupIds, orMemberOfGroupIds, tagIds, taskIds, timeEntryIds, description,
            withoutDescription, orderField?.UrlRepresentation(), orderDescending, distinctRates, rounding, displayHours)
        {
            UrlParameters.Add("page", 1);
        }

        internal void IncrementPage()
        {
            var page = UrlParameters["page"] as int? ?? 0;
            UrlParameters["page"] = page + 1;
        }
    }
}
