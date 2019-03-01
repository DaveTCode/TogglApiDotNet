namespace TogglApi.Client.Reports.Models.Response
{
    public class ReportResponseTaskTitle
    {
        public string Task { get; }

        public ReportResponseTaskTitle(string task)
        {
            Task = task;
        }
    }
}