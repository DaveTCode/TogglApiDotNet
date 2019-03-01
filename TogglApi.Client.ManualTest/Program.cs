using System;
using System.Net.Http;
using System.Threading.Tasks;
using NLog;
using TogglApi.Client.Reports;
using TogglApi.Client.Reports.Models;
using TogglApi.Client.Reports.Models.Response;

namespace TogglApi.Client.ManualTest
{
    internal static class Program
    {
        private static readonly ILogger Log = LogManager.GetCurrentClassLogger();

        private static async Task Main(string[] args)
        {
            var workspaceId = int.Parse(args[0]);
            var apiToken = args[1];
            var client = new TogglReportClient(httpClient: new HttpClient(), logger: Log);

            var report =
                await client
                    .GetSummaryReport(
                        config: new SummaryReportConfig<
                            SummaryReportResponseUserGroup<SummaryReportResponseProjectSubGroup>,
                            SummaryReportResponseProjectSubGroup>
                        (
                            userAgent: "test-app",
                            workspaceId: workspaceId
                        ),
                        apiToken: apiToken);

            Console.WriteLine(report.TotalGrand);

            var weeklyReport = await client.GetWeeklyReport(new WeeklyReportConfig<WeeklyReportResponseUserGroup>
            (
                userAgent: "test-app",
                workspaceId: workspaceId
            ), apiToken: apiToken);

            Console.WriteLine(weeklyReport.Data[0].Title.User);
        }
    }
}
