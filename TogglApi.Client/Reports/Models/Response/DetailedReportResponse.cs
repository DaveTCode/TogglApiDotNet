using System;
using System.Collections.Generic;

namespace TogglApi.Client.Reports.Models.Response
{
    public class DetailedReportResponse : ReportResponse
    {
        public List<DetailedReportDatum> Data { get; }

        internal long TotalCount { get; }

        internal long PerPage { get; }

        public DetailedReportResponse(long? totalGrand, long? totalBillable, List<TotalCurrency> totalCurrencies,
            List<DetailedReportDatum> data, long totalCount, long perPage) : base(totalGrand, totalBillable, totalCurrencies)
        {
            Data = data;
            TotalCount = totalCount;
            PerPage = perPage;
        }
    }

    public class DetailedReportDatum
    {
        public long Id { get; }
        public long? ProjectId { get; }
        public long? TaskId { get; }
        public long? UserId { get; }
        public string Description { get; }
        public DateTime Start { get; }
        public DateTime End { get; }
        public DateTime Updated { get; }
        public long DurationMs { get; }
        public string User { get; }
        public bool UseStop { get; }
        public string Client { get; }
        public string Project { get; }
        public string ProjectColor { get; }
        public string ProjectHexColor { get; }
        public string Task { get; }
        public long? BillableTimeMs { get; }
        public bool IsBillable { get; }
        public string Currency { get; }
        public List<string> Tags { get; }

        public DetailedReportDatum(long id, long? projectId, long? taskId, long? userId, string description,
            DateTime start, DateTime end, DateTime updated, long dur, string user, bool useStop, string client,
            string project, string projectColor, string projectHexColor, string task, long? billable,
            bool isBillable, string currency, List<string> tags)
        {
            Id = id;
            ProjectId = projectId;
            TaskId = taskId;
            UserId = userId;
            Description = description;
            Start = start;
            End = end;
            Updated = updated;
            DurationMs = dur;
            User = user;
            UseStop = useStop;
            Client = client;
            Project = project;
            ProjectColor = projectColor;
            ProjectHexColor = projectHexColor;
            Task = task;
            BillableTimeMs = billable;
            IsBillable = isBillable;
            Currency = currency;
            Tags = tags;
        }
    }

}
