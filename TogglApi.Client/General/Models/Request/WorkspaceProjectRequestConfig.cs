namespace TogglApi.Client.General.Models.Request
{
    public class WorkspaceProjectRequestConfig : BaseRequestConfig
    {
        public WorkspaceProjectRequestConfig(long workspaceId, bool? active=null, bool actualHours=false, bool onlyTemplates=false) 
            : base($"https://api.track.toggl.com/api/v8/workspaces/{workspaceId}/projects")
        {
            UrlParameters.Add("active", active?.ToString().ToLowerInvariant());
            UrlParameters.Add("actual_hours", actualHours.ToString().ToLowerInvariant());
            UrlParameters.Add("only_templates", onlyTemplates.ToString().ToLowerInvariant());
        }
    }
}
