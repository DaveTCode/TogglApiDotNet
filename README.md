[![Build status](https://ci.appveyor.com/api/projects/status/knoetmulr2wt5xw4/branch/master?svg=true)](https://ci.appveyor.com/project/DaveTCode/togglapidotnet/branch/master)
[![codecov](https://codecov.io/gh/DaveTCode/TogglApiDotNet/branch/master/graph/badge.svg)](https://codecov.io/gh/DaveTCode/TogglApiDotNet)

# TogglAPI

This library provides a thin layer over the [Toggl](https://toggl.com) Json API as described here: https://github.com/toggl/toggl_api_docs.

Contributions are welcome, please submit issues or PRs.

## Report API Usage

Get weekly report grouped by users for the most recent week:
```
var client = new TogglReportClient(httpClient: new HttpClient(), logger: Log);

var weeklyReport = await client.GetWeeklyReport(new WeeklyReportConfig<WeeklyReportResponseUserGroup>
            (
                userAgent: "test-app",
                workspaceId: workspaceId
            ), apiToken: apiToken);

Console.WriteLine(weeklyReport.Data[0].Title.User);
```

Get detailed report for fixed time period:
```
var detailedReport = await client.GetDetailedReport(new DetailedReportConfig
            (
                userAgent: "test-app",
                workspaceId: workspaceId,
                since: DateTime.UtcNow.AddDays(-14),
                until: DateTime.UtcNow
            ), apiToken: apiToken);
```

## Development

### Requirements

The library is written for .NET Standard 2.0 and is developed with the [.NET Core 2.2 SDK](https://dotnet.microsoft.com/download).

### Testing

There are no automated tests for this library at present. There is a manual test application which can be called from the command line using:
`dotnet run --project .\TogglApi.Client.ManualTest\TogglApi.Client.ManualTest.csproj -- <workspaceId> <apiKey>`

where you can get your Api key from https://toggl.com/app/profile.
