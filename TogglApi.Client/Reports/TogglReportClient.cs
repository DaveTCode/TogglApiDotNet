using System.Net.Http;
using System.Threading.Tasks;
using NLog;
using TogglApi.Client.Reports.Models;
using TogglApi.Client.Reports.Models.Response;

namespace TogglApi.Client.Reports
{
    public class TogglReportClient : BaseTogglClient
    {
        public TogglReportClient(HttpClient httpClient, ILogger logger) : base(httpClient, logger)
        {
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
            var totalData = await GetGenericTogglApi<DetailedReportResponse>(config.GenerateUrl(), apiToken).ConfigureAwait(false);

            if (totalData.TotalCount <= totalData.PerPage)
            {
                return totalData;
            }

            // Data in the detailed report can be paged if it has more than
            // 50 rows.
            for (var page = 2; page <= 1 + (totalData.TotalCount / totalData.PerPage); page++)
            {
                config.IncrementPage();
                var partialData = await GetGenericTogglApi<DetailedReportResponse>(config.GenerateUrl(), apiToken).ConfigureAwait(false);

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
            return await GetGenericTogglApi<WeeklyReportResponse<T>>(config.GenerateUrl(), apiToken).ConfigureAwait(false);
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

            return await GetGenericTogglApi<SummaryReportResponse<TGrouping, TSubGrouping>>(config.GenerateUrl(),
                apiToken).ConfigureAwait(false);
        }
    }
}
