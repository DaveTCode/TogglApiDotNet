using System;
using System.Collections.Generic;
using System.Net;
using TogglApi.Client.Reports.Models.Request;

namespace TogglApi.Client.Reports.Models
{
    public abstract class ReportConfig
    {
        private readonly ReportType _reportType;
        private readonly string _userAgent;
        private readonly int _workspaceId;
        private readonly DateTime? _since;
        private readonly DateTime? _until;
        private readonly BillableOptions? _billableOptions;
        private readonly IList<int> _clientIds;
        private readonly IList<int> _projectIds;
        private readonly IList<int> _userIds;
        private readonly IList<int> _memberOfGroupIds;
        private readonly IList<int> _orMemberOfGroupIds;
        private readonly IList<int> _tagIds;
        private readonly IList<int> _taskIds;
        private readonly IList<int> _timeEntryIds;
        private readonly string _description;
        private readonly bool _withoutDescription;
        private readonly string _orderField;
        private readonly bool _orderDescending;
        private readonly bool _distinctRates;
        private readonly bool _rounding;
        private readonly DisplayHours? _displayHours;

        protected ReportConfig(ReportType reportType, string userAgent, int workspaceId, DateTime? since = null, DateTime? until = null, BillableOptions? billableOptions = null,
            IList<int> clientIds = null, IList<int> projectIds = null, IList<int> userIds = null,
            IList<int> memberOfGroupIds = null, IList<int> orMemberOfGroupIds = null, IList<int> tagIds = null,
            IList<int> taskIds = null, IList<int> timeEntryIds = null, string description = null,
            bool withoutDescription = false, string orderField = null, bool orderDescending = false,
            bool distinctRates = false, bool rounding = false, DisplayHours? displayHours = null)
        {
            _reportType = reportType;
            _userAgent = userAgent;
            _workspaceId = workspaceId;
            _since = since;
            _until = until;
            _billableOptions = billableOptions;
            _clientIds = clientIds;
            _projectIds = projectIds;
            _userIds = userIds;
            _memberOfGroupIds = memberOfGroupIds;
            _orMemberOfGroupIds = orMemberOfGroupIds;
            _tagIds = tagIds;
            _taskIds = taskIds;
            _timeEntryIds = timeEntryIds;
            _description = description;
            _withoutDescription = withoutDescription;
            _orderField = orderField;
            _orderDescending = orderDescending;
            _distinctRates = distinctRates;
            _rounding = rounding;
            _displayHours = displayHours;
        }

        internal virtual string GenerateUrl()
        {
            // Mandatory parameters
            var queryParams = $"user_agent={_userAgent}&workspace_id={_workspaceId}";

            if (_since != null)
            {
                queryParams += $"&since={_since?.ToString("yyyy-MM-dd")}";
            }

            if (_until != null)
            {
                queryParams += $"&until={_until?.ToString("yyyy-MM-dd")}";
            }

            if (_billableOptions != null)
            {
                queryParams += $"&billable={_billableOptions?.UrlRepresentation()}";
            }

            if (_clientIds != null)
            {
                queryParams += $"&client_ids={string.Join(",", _clientIds)}";
            }

            if (_projectIds != null)
            {
                queryParams += $"&project_ids={string.Join(",", _projectIds)}";
            }

            if (_userIds != null)
            {
                queryParams += $"&user_ids={string.Join(",", _userIds)}";
            }

            if (_memberOfGroupIds != null)
            {
                queryParams += $"&member_of_group_ids={string.Join(",", _memberOfGroupIds)}";
            }

            if (_orMemberOfGroupIds != null)
            {
                queryParams += $"&or_member_of_group_ids={string.Join(",", _orMemberOfGroupIds)}";
            }

            if (_tagIds != null)
            {
                queryParams += $"&tag_ids={string.Join(",", _tagIds)}";
            }

            if (_taskIds != null)
            {
                queryParams += $"&task_ids={string.Join(",", _taskIds)}";
            }

            if (_timeEntryIds != null)
            {
                queryParams += $"&time_entry_ids={string.Join(",", _timeEntryIds)}";
            }

            if (_description != null)
            {
                queryParams += $"&description={WebUtility.UrlEncode(_description)}";
            }

            queryParams += $"&without_description={_withoutDescription.ToString().ToLowerInvariant()}";
            if (_orderField != null)
            {
                queryParams += $"&order_field=${WebUtility.UrlEncode(_orderField)}";
            }

            queryParams += $"&order_descending={_orderDescending.ToString().ToLowerInvariant()}";
            queryParams += $"&distinct_rates={_distinctRates.ToString().ToLowerInvariant()}";
            queryParams += $"&rounding={_rounding.ToString().ToLowerInvariant()}";

            if (_displayHours != null)
            {
                queryParams += $"&display_hours={_displayHours?.UrlRepresentation()}";
            }

            return $"https://toggl.com/reports/api/v2/{_reportType.UrlRepresentation()}?{queryParams}";
        }
    }
}
