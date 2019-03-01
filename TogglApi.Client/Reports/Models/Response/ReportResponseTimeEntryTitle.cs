namespace TogglApi.Client.Reports.Models.Response
{
    public class ReportResponseTimeEntryTitle
    {
        public string TimeEntry { get; }

        public ReportResponseTimeEntryTitle(string timeEntry)
        {
            TimeEntry = timeEntry;
        }
    }
}