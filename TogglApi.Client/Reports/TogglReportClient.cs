using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NLog;
using TogglApi.Client.Reports.Models;
using TogglApi.Client.Reports.Models.Response;

namespace TogglApi.Client.Reports
{
    public class TogglReportClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger _logger;
        private readonly JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            }
        };

        public TogglReportClient(HttpClient httpClient, ILogger logger)
        {
            _httpClient = httpClient;
            _logger = logger;
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private async Task<HttpResponseMessage> GetGenericReportApi(string url, string apiToken)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(Encoding.UTF8.GetBytes($"{apiToken}:api_token")));

            var retries = 0;
            const int maxRetries = 3;
            HttpResponseMessage response = null;
            while (retries < maxRetries)
            {
                response = await _httpClient.SendAsync(request);

                // ReSharper disable once SwitchStatementMissingSomeCases
                switch (response.StatusCode)
                {
                    case HttpStatusCode.TooManyRequests:
                        _logger.Info("Rate limited request, pausing before retrying");
                        await Task.Delay(1000 * (retries + 1));
                        break;
                    default:
                        return response;
                }

                retries++;
            }

            return response;
        }

        /// <summary>
        /// Get the full set of paged results from the detailed api as defined here:
        /// https://github.com/toggl/toggl_api_docs/blob/master/reports/detailed.md
        /// </summary>
        /// 
        /// <param name="config">
        /// A populated config object defining the parameters used to generate
        /// the report.
        /// </param>
        ///
        /// <param name="apiToken">
        /// The API token as defined in your profile on Toggl.
        /// </param>
        ///
        /// <returns>
        /// A task which resolves to the full response (all pages of data
        /// included).
        /// </returns>
        public async Task<DetailedReportResponse> GetDetailedReport(DetailedReportConfig config, string apiToken)
        {
            var response = await GetGenericReportApi(config.GenerateUrl(), apiToken);

            var totalData = JsonConvert.DeserializeObject<DetailedReportResponse>(
                await response.Content.ReadAsStringAsync(),
                _jsonSerializerSettings);

            if (totalData.TotalCount <= totalData.PerPage) return totalData;

            // Data in the detailed report can be paged if it has more than
            // 50 rows.
            for (var page = 2; page <= 1 + (totalData.TotalCount / totalData.PerPage); page++)
            {
                config.Page = page;
                response = await GetGenericReportApi(config.GenerateUrl(), apiToken);

                var partialData = JsonConvert.DeserializeObject<DetailedReportResponse>(
                    await response.Content.ReadAsStringAsync(),
                    _jsonSerializerSettings);

                totalData.Data.AddRange(partialData.Data);
            }

            return totalData;
        }

        /// <summary>
        /// Get a weekly summary report from Toggl as per the API docs here:
        /// https://github.com/toggl/toggl_api_docs/blob/master/reports/weekly.md
        /// </summary>
        /// 
        /// <param name="config">
        /// A populated config object defining the parameters used to generate
        /// the report.
        /// </param>
        ///
        /// <param name="apiToken">
        /// The API token as defined in your profile on Toggl.
        /// </param>
        ///
        /// <returns>
        /// A task which resolves to the full response.
        /// </returns>
        public async Task<WeeklyReportResponse<T>> GetWeeklyReport<T>(WeeklyReportConfig<T> config, string apiToken)
            where T : WeeklyReportResponseGroup
        {
            var response = await GetGenericReportApi(config.GenerateUrl(), apiToken);

            // TODO - Handle non-200 result codes

            return JsonConvert.DeserializeObject<WeeklyReportResponse<T>>(
                await response.Content.ReadAsStringAsync(),
                _jsonSerializerSettings);
        }

        /// <summary>
        /// Creates a summary report as per
        /// https://github.com/toggl/toggl_api_docs/blob/master/reports/summary.md.
        /// </summary>
        /// 
        /// <typeparam name="TGrouping">
        /// This type defines the 
        /// </typeparam>
        ///
        /// <typeparam name="TSubGrouping"></typeparam>
        ///
        /// <param name="config"></param>
        ///
        /// <param name="apiToken"></param>
        ///
        /// <returns></returns>
        public async Task<SummaryReportResponse<TGrouping, TSubGrouping>> GetSummaryReport<TGrouping, TSubGrouping>(
            SummaryReportConfig<TGrouping, TSubGrouping> config, string apiToken)
            where TGrouping : SummaryReportResponseGroup<TSubGrouping>
            where TSubGrouping : SummaryReportResponseSubGroup
        {
            // TODO - How to validate that the group/subgroup is allowed?

            var response = await GetGenericReportApi(config.GenerateUrl(), apiToken);

            // TODO - Handle non-200 result codes

            return JsonConvert.DeserializeObject<SummaryReportResponse<TGrouping, TSubGrouping>>(
                await response.Content.ReadAsStringAsync(),
                _jsonSerializerSettings);
        }
    }
}
