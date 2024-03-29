﻿using System;
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
        public async Task TestGetWorkspacesValidResponse()
        {
            var (client, handlerMock) = await MockedClientHelper.CreateMockedClient(Log, "valid_workspaces.json");
            var workspaces = await client.GetWorkspaces("");

            Assert.Single(workspaces);
            Assert.Equal(1, workspaces[0].WorkspaceId);
            Assert.Equal("A", workspaces[0].Name);
            Assert.Equal("USD", workspaces[0].DefaultCurrency);

            MockedClientHelper.ValidateUrlRequest("https://api.track.toggl.com/api/v8/workspaces", handlerMock);
        }

        [Fact]
        public async Task TestGetSingleWorkspaceValidResponse()
        {
            var (client, handlerMock) = await MockedClientHelper.CreateMockedClient(Log, "valid_workspace.json");
            var workspace = await client.GetWorkspace("", 1);

            Assert.Equal(1, workspace.WorkspaceId);
            Assert.Equal("A", workspace.Name);
            Assert.Equal("USD", workspace.DefaultCurrency);

            MockedClientHelper.ValidateUrlRequest("https://api.track.toggl.com/api/v8/workspaces/1", handlerMock);
        }

        [Fact]
        public async Task TestGetGroupsValidResponse()
        {
            var (client, handlerMock) = await MockedClientHelper.CreateMockedClient(Log, "valid_groups.json");
            var groups = await client.GetGroups("", new WorkspaceGroupRequestConfig(1));

            Assert.Equal(2, groups.Count);
            Assert.Equal(1, groups[0].GroupId);
            Assert.Equal(1, groups[0].WorkspaceId);
            Assert.Equal("A Team", groups[0].Name);

            MockedClientHelper.ValidateUrlRequest("https://api.track.toggl.com/api/v8/workspaces/1/groups", handlerMock);
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

            MockedClientHelper.ValidateUrlRequest("https://api.track.toggl.com/api/v8/workspaces/1/projects", handlerMock);
        }

        [Fact]
        public async Task TestGetUsersValidResponse()
        {
            var (client, handlerMock) = await MockedClientHelper.CreateMockedClient(Log, "valid_users.json");
            var users = await client.GetUsers("", 1);

            Assert.Equal(2, users.Count);
            Assert.Equal(1, users[0].UserId);
            Assert.Equal("a@a.com", users[0].Email);
            Assert.Equal("A A", users[0].Fullname);

            MockedClientHelper.ValidateUrlRequest("https://api.track.toggl.com/api/v8/workspaces/1/users", handlerMock);
        }

        [Fact]
        public async Task TestGetClientsValidResponse()
        {
            var (client, handlerMock) = await MockedClientHelper.CreateMockedClient(Log, "valid_clients.json");
            var clients = await client.GetClients("", 1);

            Assert.Equal(3, clients.Count);
            Assert.Equal(1, clients[0].ClientId);
            Assert.Equal(1, clients[0].WorkspaceId);
            Assert.Equal("A", clients[0].Name);
            Assert.Equal(new DateTime(2019, 2, 27, 16, 31, 22), clients[0].At);

            MockedClientHelper.ValidateUrlRequest("https://api.track.toggl.com/api/v8/workspaces/1/users", handlerMock);
        }

        [Fact]
        public async Task TestGetTagsValidResponse()
        {
            var (client, handlerMock) = await MockedClientHelper.CreateMockedClient(Log, "valid_tags.json");
            var tags = await client.GetTags("", 1);

            Assert.Equal(2, tags.Count);
            Assert.Equal(1, tags[0].TagId);
            Assert.Equal(1, tags[0].WorkspaceId);
            Assert.Equal("A", tags[0].Name);
            Assert.Equal(new DateTime(2018, 6, 28, 12, 42, 37), tags[0].At);

            MockedClientHelper.ValidateUrlRequest("https://api.track.toggl.com/api/v8/workspaces/1/tags", handlerMock);
        }

        [Fact]
        public async Task TestGetTasksValidResponse()
        {
            var (client, handlerMock) = await MockedClientHelper.CreateMockedClient(Log, "valid_tasks.json");
            var tasks = await client.GetTasks("", new WorkspaceTaskRequestConfig(1));

            Assert.Equal(2, tasks.Count);
            Assert.Equal(1, tasks[0].TaskId);
            Assert.Equal(1, tasks[0].WorkspaceId);
            Assert.Equal("A", tasks[0].Name);
            Assert.Equal(new DateTime(2017, 5, 9, 8, 8, 51), tasks[0].At);

            MockedClientHelper.ValidateUrlRequest("https://api.track.toggl.com/api/v8/workspaces/1/tasks", handlerMock);
        }
    }
}
