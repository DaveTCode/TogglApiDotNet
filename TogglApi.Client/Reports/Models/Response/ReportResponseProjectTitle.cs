namespace TogglApi.Client.Reports.Models.Response
{
    public class ReportResponseProjectTitle
    {
        public string Project { get; }

        public string Client { get; }

        public ReportResponseProjectTitle(string client, string project)
        {
            Client = client;
            Project = project;
        }
    }
}