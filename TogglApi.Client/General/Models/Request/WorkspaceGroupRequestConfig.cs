namespace TogglApi.Client.General.Models.Request
{
    public class WorkspaceGroupRequestConfig : BaseRequestConfig
    {
        public WorkspaceGroupRequestConfig(long workspaceId) : base($"https://api.track.toggl.com/api/v8/workspaces/{workspaceId}/groups")
        {
        }
    }
}
