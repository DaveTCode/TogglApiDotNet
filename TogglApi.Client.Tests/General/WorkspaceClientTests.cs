using System.Threading.Tasks;
using NLog;
using TogglApi.Client.General.Models.Request;
using Xunit;

namespace TogglApi.Client.Tests.General
{
    public class WorkspaceClientTests
    {
        private static readonly ILogger Log = LogManager.GetCurrentClassLogger();

        [Fact]
        public async Task TestGetGroupsValidResponse()
        {
            var (client, handlerMock) = await MockedClientHelper.CreateMockedClient(Log, "valid_groups.json");
            var groups = await client.GetGroups("", new WorkspaceGroupRequestConfig(1));
 
            Assert.Equal(2, groups.Count);
            Assert.Equal(1, groups[0].GroupId);
            Assert.Equal(1, groups[0].WorkspaceId);
            Assert.Equal("A Team", groups[0].Name);
 
            MockedClientHelper.ValidateUrlRequest("https://www.toggl.com/api/v8/workspaces/1/groups", handlerMock);
        }

        [Fact]
        public async Task TestGetProjectsValidResponse()
        {
            var (client, handlerMock) = await MockedClientHelper.CreateMockedClient(Log, "valid_projects.json");
            var projects = await client.GetProjects("", new WorkspaceProjectRequestConfig(1));
 
            Assert.Equal(2, projects.Count);
            Assert.Equal(1, projects[0].ProjectId);
            Assert.Equal(1, projects[0].WorkspaceId);
            Assert.Equal("A", projects[0].Name);
 
            MockedClientHelper.ValidateUrlRequest("https://www.toggl.com/api/v8/workspaces/1/projects", handlerMock);
        }
    }
}
