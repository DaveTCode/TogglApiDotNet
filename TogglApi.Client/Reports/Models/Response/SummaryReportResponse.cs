using System.Collections.Generic;
using Newtonsoft.Json;

namespace TogglApi.Client.Reports.Models.Response
{
    public class SummaryReportResponse<TGrouping, TSubGrouping> : ReportResponse
        where TGrouping : SummaryReportResponseGroup<TSubGrouping>
        where TSubGrouping : SummaryReportResponseSubGroup
    {
        public List<TGrouping> Data { get; }

        public SummaryReportResponse(long totalGrand, long totalBillable, List<TotalCurrency> totalCurrencies,
            List<TGrouping> data) : base(totalGrand, totalBillable, totalCurrencies)
        {
            Data = data;
        }
    }

    public abstract class SummaryReportResponseGroup<T>
        where T : SummaryReportResponseSubGroup
    {
        public long? Id { get; }

        public long Time { get; }

        public List<TotalCurrency> TotalCurrencies { get; }

        public List<T> Items { get; }

        public SummaryReportResponseGroup(long? id, long time, List<TotalCurrency> totalCurrencies, List<T> items)
        {
            Id = id;
            Time = time;
            TotalCurrencies = totalCurrencies;
            Items = items;
        }
    }

    public abstract class SummaryReportResponseSubGroup
    {
        public long Time { get; }

        public string Currency { get; }

        public long Sum { get; }

        public long Rate { get; }

        public SummaryReportResponseSubGroup(long time, string currency, long sum, long rate)
        {
            Time = time;
            Currency = currency;
            Sum = sum;
            Rate = rate;
        }
    }

    [ToggleApiUrlValue("projects")]
    public class SummaryReportResponseProjectGroup<T> : SummaryReportResponseGroup<T>
        where T : SummaryReportResponseSubGroup
    {
        public ReportResponseProjectTitle Title { get; }

        public SummaryReportResponseProjectGroup(long? id, long time, List<TotalCurrency> totalCurrencies, 
            List<T> items, ReportResponseProjectTitle title) : base(id, time, totalCurrencies, items)
        {
            Title = title;
        }
    }

    [ToggleApiUrlValue("clients")]
    public class SummaryReportResponseClientGroup<T> : SummaryReportResponseGroup<T>
        where T : SummaryReportResponseSubGroup
    {
        public ReportResponseClientTitle Title { get; }

        public SummaryReportResponseClientGroup(long? id, long time, List<TotalCurrency> totalCurrencies, 
            List<T> items, ReportResponseClientTitle title) : base(id, time, totalCurrencies, items)
        {
            Title = title;
        }
    }

    [ToggleApiUrlValue("users")]
    public class SummaryReportResponseUserGroup<T> : SummaryReportResponseGroup<T>
        where T : SummaryReportResponseSubGroup
    {
        public ReportResponseUserTitle Title { get; }

        public SummaryReportResponseUserGroup(long? id, long time, List<TotalCurrency> totalCurrencies, 
            List<T> items, ReportResponseUserTitle title) : base(id, time, totalCurrencies, items)
        {
            Title = title;
        }
    }

    [ToggleApiUrlValue("projects")]
    public class SummaryReportResponseProjectSubGroup : SummaryReportResponseSubGroup
    {
        public ReportResponseProjectTitle Title { get; }

        [JsonConstructor]
        public SummaryReportResponseProjectSubGroup(long time, string cur, long sum, long rate, 
            ReportResponseProjectTitle title) : base(time, cur, sum, rate)
        {
            Title = title;
        }
    }

    [ToggleApiUrlValue("clients")]
    public class SummaryReportResponseClientSubGroup : SummaryReportResponseSubGroup
    {
        public ReportResponseClientTitle Title { get; }

        public SummaryReportResponseClientSubGroup(long time, string cur, long sum, long rate, 
            ReportResponseClientTitle title) : base(time, cur, sum, rate)
        {
            Title = title;
        }
    }

    [ToggleApiUrlValue("users")]
    public class SummaryReportResponseUserSubGroup : SummaryReportResponseSubGroup
    {
        public ReportResponseUserTitle Title { get; }

        public SummaryReportResponseUserSubGroup(long time, string cur, long sum, long rate, 
            ReportResponseUserTitle title) : base(time, cur, sum, rate)
        {
            Title = title;
        }
    }

    [ToggleApiUrlValue("tasks")]
    public class SummaryReportResponseTaskSubGroup : SummaryReportResponseSubGroup
    {
        public ReportResponseTaskTitle Title { get; }

        public SummaryReportResponseTaskSubGroup(long time, string cur, long sum, long rate, 
            ReportResponseTaskTitle title) : base(time, cur, sum, rate)
        {
            Title = title;
        }
    }

    [ToggleApiUrlValue("time_entries")]
    public class SummaryReportResponseTimeEntrySubGroup : SummaryReportResponseSubGroup
    {
        public ReportResponseTimeEntryTitle Title { get; }

        public SummaryReportResponseTimeEntrySubGroup(long time, string cur, long sum, long rate, 
            ReportResponseTimeEntryTitle title) : base(time, cur, sum, rate)
        {
            Title = title;
        }
    }
}
