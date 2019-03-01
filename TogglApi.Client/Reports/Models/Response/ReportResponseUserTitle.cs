namespace TogglApi.Client.Reports.Models.Response
{
    public class ReportResponseUserTitle
    {
        public string User { get; }

        public ReportResponseUserTitle(string user)
        {
            User = user;
        }
    }
}