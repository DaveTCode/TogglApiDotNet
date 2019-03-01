namespace TogglApi.Client
{
    /// <summary>
    /// Contains constant configuration about Toggl as a whole
    /// </summary>
    public class Configuration
    {
        /// <summary>
        /// The root URL for API routes, includes the API version
        /// </summary>
        public string ApiBaseUrl { get; }

        /// <summary>
        /// The root URL for the reports API, includes the API version
        /// </summary>
        public string ReportsApiBaseUrl { get; }

        /// <summary>
        /// The root URL for the web application
        /// </summary>
        public string WebBaseUrl { get; }

        public Configuration(string apiBaseUrl = "https://www.toggl.com/api/v8",
            string reportsApiBaseUrl = "https://toggl.com/reports/api/v2",
            string webBaseUrl = "https://www.toggl.com/app")
        {
            ApiBaseUrl = apiBaseUrl;
            ReportsApiBaseUrl = reportsApiBaseUrl;
            WebBaseUrl = webBaseUrl;
        }
    }
}
