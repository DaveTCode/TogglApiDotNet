using System;
using System.Collections.Generic;
using System.Globalization;
using TogglApi.Client.Reports.Models.Request;

namespace TogglApi.Client.Reports.Models
{
    public abstract class ReportConfig : BaseRequestConfig
    {
        protected ReportConfig(ReportType reportType, string userAgent, long workspaceId, DateTime? since = null, DateTime? until = null, BillableOptions? billableOptions = null,
            IList<int> clientIds = null, IList<int> projectIds = null, IList<int> userIds = null,
            IList<int> memberOfGroupIds = null, IList<int> orMemberOfGroupIds = null, IList<int> tagIds = null,
            IList<int> taskIds = null, IList<int> timeEntryIds = null, string description = null,
            bool withoutDescription = false, string orderField = null, bool orderDescending = false,
            bool distinctRates = false, bool rounding = false, DisplayHours? displayHours = null) :
            base($"https://toggl.com/reports/api/v2/{reportType.UrlRepresentation()}")
        {
            UrlParameters.Add("user_agent", userAgent);
            UrlParameters.Add("workspace_id", workspaceId);
            UrlParameters.Add("since", since?.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
            UrlParameters.Add("until", until?.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
            UrlParameters.Add("billable", billableOptions?.UrlRepresentation());
            UrlParameters.Add("client_ids", (clientIds == null) ? null : string.Join(",", clientIds));
            UrlParameters.Add("project_ids", (projectIds == null) ? null : string.Join(",", projectIds));
            UrlParameters.Add("user_ids", (userIds == null) ? null : string.Join(",", userIds));
            UrlParameters.Add("member_of_group_ids", (memberOfGroupIds == null) ? null : string.Join(",", memberOfGroupIds));
            UrlParameters.Add("or_member_of_group_ids", (orMemberOfGroupIds == null) ? null : string.Join(",", orMemberOfGroupIds));
            UrlParameters.Add("tag_ids", (tagIds == null) ? null : string.Join(",", tagIds));
            UrlParameters.Add("task_ids", (taskIds == null) ? null : string.Join(",", taskIds));
            UrlParameters.Add("time_entry_ids", (timeEntryIds == null) ? null : string.Join(",", timeEntryIds));
            UrlParameters.Add("description", description);
            UrlParameters.Add("without_description", withoutDescription.ToString().ToLowerInvariant());
            UrlParameters.Add("order_field", orderField);
            UrlParameters.Add("order_descending", orderDescending.ToString().ToLowerInvariant());
            UrlParameters.Add("distinct_rates", distinctRates.ToString().ToLowerInvariant());
            UrlParameters.Add("rounding", rounding.ToString().ToLowerInvariant());
            UrlParameters.Add("display_hours", displayHours?.UrlRepresentation());
        }
    }
}
