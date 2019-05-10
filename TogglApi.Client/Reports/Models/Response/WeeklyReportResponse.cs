using System.Collections.Generic;

namespace TogglApi.Client.Reports.Models.Response
{
    public class WeeklyReportResponse<T> : ReportResponse
        where T : WeeklyReportResponseGroup
    {
        public List<long?> WeekTotals { get; }

        public List<T> Data { get; }

        public WeeklyReportResponse(long? totalGrand, long? totalBillable, List<TotalCurrency> totalCurrencies,
            List<long?> weekTotals, List<T> data) : base(totalGrand, totalBillable, totalCurrencies)
        {
            WeekTotals = weekTotals;
            Data = data;
        }
    }

    public abstract class WeeklyReportResponseGroup
    {
        public List<long?> Totals { get; }

        public WeeklyReportResponseGroup(List<long?> totals)
        {
            Totals = totals;
        }
    }

    public class WeeklyReportResponseProjectItem : WeeklyReportResponseGroup
    {
        public long? ProjectId { get; }

        public ReportResponseProjectTitle Title { get; }

        public WeeklyReportResponseProjectItem(List<long?> totals, long? pid, ReportResponseProjectTitle title) : base(totals)
        {
            ProjectId = pid;
            Title = title;
        }
    }

    public class WeeklyReportResponseUserItem : WeeklyReportResponseGroup
    {
        public long? UserId { get; }

        public ReportResponseUserTitle Title { get; }

        public WeeklyReportResponseUserItem(List<long?> totals, long? uid, ReportResponseUserTitle title) : base(totals)
        {
            UserId = uid;
            Title = title;
        }
    }

    [ToggleApiUrlValue("projects")]
    public class WeeklyReportResponseProjectGroup : WeeklyReportResponseProjectItem
    {
        public List<WeeklyReportResponseUserItem> Details { get; }

        public WeeklyReportResponseProjectGroup(List<long?> totals, long? pid, ReportResponseProjectTitle title, 
            List<WeeklyReportResponseUserItem> details) : base(totals, pid, title)
        {
            Details = details;
        }
    }

    [ToggleApiUrlValue("users")]
    public class WeeklyReportResponseUserGroup : WeeklyReportResponseUserItem
    {
        public List<WeeklyReportResponseProjectItem> Details { get; }

        public WeeklyReportResponseUserGroup(List<long?> totals, long? uid, ReportResponseUserTitle title, 
            List<WeeklyReportResponseProjectItem> details) : base(totals, uid, title)
        {
            Details = details;
        }
    }
}
