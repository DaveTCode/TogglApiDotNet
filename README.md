[![CI Build](https://github.com/DaveTCode/TogglApiDotNet/actions/workflows/build.yml/badge.svg)](https://github.com/DaveTCode/TogglApiDotNet/actions/workflows/build.yml)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=DaveTCode_TogglApiDotNet&metric=alert_status)](https://sonarcloud.io/dashboard?id=DaveTCode_TogglApiDotNet)
[![codecov](https://codecov.io/gh/DaveTCode/TogglApiDotNet/branch/master/graph/badge.svg)](https://codecov.io/gh/DaveTCode/TogglApiDotNet)
[![NuGet](https://img.shields.io/nuget/v/TogglApi.Client.svg)](https://www.nuget.org/packages/TogglApi.Client/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

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

There are a small suite of unit tests which mock out the Toggl API with canned responses as laid out in the TogglApi.Client.Tests project. These can be run 
from the command line with `dotnet test`.

There is also a manual test application which can be called from the command line using:
`dotnet run --project .\TogglApi.Client.ManualTest\TogglApi.Client.ManualTest.csproj -- <workspaceId> <apiKey>`

where you can get your Api key from https://toggl.com/app/profile.
