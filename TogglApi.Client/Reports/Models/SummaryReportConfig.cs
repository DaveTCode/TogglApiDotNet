using System;
using System.Collections.Generic;
using System.Reflection;
using TogglApi.Client.Reports.Models.Request;
using TogglApi.Client.Reports.Models.Response;

namespace TogglApi.Client.Reports.Models
{
    public class SummaryReportConfig<TGrouping, TSubgrouping> : ReportConfig
        where TGrouping : SummaryReportResponseGroup<TSubgrouping>
        where TSubgrouping : SummaryReportResponseSubGroup
    {
        public SummaryReportConfig(string userAgent, int workspaceId, DateTime? since = null,
            DateTime? until = null, BillableOptions? billableOptions = null, IList<int> clientIds = null,
            IList<int> projectIds = null, IList<int> userIds = null, IList<int> memberOfGroupIds = null,
            IList<int> orMemberOfGroupIds = null, IList<int> tagIds = null, IList<int> taskIds = null,
            IList<int> timeEntryIds = null, string description = null, bool withoutDescription = false,
            SummaryOrderField? orderField = null, bool orderDescending = false, bool distinctRates = false,
            bool rounding = false, DisplayHours? displayHours = null) : base(ReportType.Summary, userAgent, workspaceId, since,
            until, billableOptions, clientIds, projectIds, userIds, memberOfGroupIds, orMemberOfGroupIds, tagIds,
            taskIds, timeEntryIds, description, withoutDescription, orderField?.UrlRepresentation(), orderDescending,
            distinctRates, rounding, displayHours)
        {
        }

        internal override string GenerateUrl()
        {
            var url = base.GenerateUrl();

            if (typeof(TGrouping).GetCustomAttribute(typeof(ToggleApiUrlValueAttribute)) is
                ToggleApiUrlValueAttribute groupingAttribute)
            {
                url += $"&grouping={groupingAttribute.UrlValue}";
            }

            if (typeof(TSubgrouping).GetCustomAttribute(typeof(ToggleApiUrlValueAttribute)) is
                ToggleApiUrlValueAttribute subGroupingAttribute)
            {
                url += $"&subgrouping={subGroupingAttribute.UrlValue}";
            }

            // Note that we default these to true to simplify the resulting model
            url += "&subgrouping_ids=true";
            url += "&grouped_time_entry_ids=true";
            return url;
        }
    }
}
