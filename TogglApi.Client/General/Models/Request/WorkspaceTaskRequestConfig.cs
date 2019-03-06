using System;
using System.Collections.Generic;
using System.Text;

namespace TogglApi.Client.General.Models.Request
{
    public class WorkspaceTaskRequestConfig : BaseRequestConfig
    {
        public WorkspaceTaskRequestConfig(long workspaceId, bool? active=null) : base(
            $"https://www.toggl.com/api/v8/workspaces/{workspaceId}/tasks")
        {
            UrlParameters.Add("active", active?.ToString().ToLowerInvariant());
        }
    }
}
