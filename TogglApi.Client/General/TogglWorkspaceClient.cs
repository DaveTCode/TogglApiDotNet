﻿using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using NLog;
using TogglApi.Client.General.Models.Request;
using TogglApi.Client.General.Models.Response;

namespace TogglApi.Client.General
{
    public class TogglWorkspaceClient : BaseTogglClient
    {
        public TogglWorkspaceClient(HttpClient httpClient, ILogger logger) : base(httpClient, logger)
        {
        }

        public async Task<List<Project>> GetProjects(string apiToken, WorkspaceProjectRequestConfig config)
        {
            return await GetGenericReportApi<List<Project>>(url: config.GenerateUrl(), apiToken: apiToken);
        }

        public async Task<List<Group>> GetGroups(string apiToken, WorkspaceGroupRequestConfig config)
        {
            return await GetGenericReportApi<List<Group>>(url: config.GenerateUrl(), apiToken: apiToken);
        }

        public async Task<List<User>> GetUsers(string apiToken, long workspaceId)
        {
            return await GetGenericReportApi<List<User>>(
                url: $"https://www.toggl.com/api/v8/workspaces/{workspaceId}/users", apiToken: apiToken);
        }

        public async Task<List<Models.Response.Client>> GetClients(string apiToken, long workspaceId)
        {
            return await GetGenericReportApi<List<Models.Response.Client>>(
                url: $"https://www.toggl.com/api/v8/workspaces/{workspaceId}/users", apiToken: apiToken);
        }
    }
}
