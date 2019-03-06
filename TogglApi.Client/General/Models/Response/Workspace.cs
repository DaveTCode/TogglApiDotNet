using System;

namespace TogglApi.Client.General.Models.Response
{
    public class Workspace
    {
        public long WorkspaceId { get; }

        public string Name { get; }

        public long Profile { get; }

        public bool Premium { get; }

        public bool Admin { get; }

        public long DefaultHourlyRate { get; }

        public string DefaultCurrency { get; }

        public bool OnlyAdminsMayCreateProjects { get; }

        public bool OnlyAdminsSeeBillableRates { get; }

        public bool OnlyAdminsSeeTeamDashboard { get; }

        public bool ProjectsBillableByDefault { get; }

        public long Rounding { get; }

        public long RoundingMinutes { get; }

        public string ApiToken { get; }

        public DateTime At { get; }

        public Uri LogoUrl { get; }

        public string IcalUrl { get; }

        public bool IcalEnabled { get; }

        public dynamic CsvUpload { get; }

        public Workspace(long id, string name, long profile, bool premium, bool admin, long defaultHourlyRate,
            string defaultCurrency, bool onlyAdminsMayCreateProjects, bool onlyAdminsSeeBillableRates,
            bool onlyAdminsSeeTeamDashboard, bool projectsBillableByDefault, long rounding, long roundingMinutes,
            string apiToken, DateTime at, Uri logoUrl, string icalUrl, bool icalEnabled, dynamic csvUpload)
        {
            WorkspaceId = id;
            Name = name;
            Profile = profile;
            Premium = premium;
            Admin = admin;
            DefaultHourlyRate = defaultHourlyRate;
            DefaultCurrency = defaultCurrency;
            OnlyAdminsMayCreateProjects = onlyAdminsMayCreateProjects;
            OnlyAdminsSeeBillableRates = onlyAdminsSeeBillableRates;
            OnlyAdminsSeeTeamDashboard = onlyAdminsSeeTeamDashboard;
            ProjectsBillableByDefault = projectsBillableByDefault;
            Rounding = rounding;
            RoundingMinutes = roundingMinutes;
            ApiToken = apiToken;
            At = at;
            LogoUrl = logoUrl;
            IcalUrl = icalUrl;
            IcalEnabled = icalEnabled;
            CsvUpload = csvUpload;
        }
    }

    /// <summary>
    /// The Toggl API returns single entries wrapped in a data object, this is
    /// only used for deserializing workspaces on the API.
    /// </summary>
    public class WorkspaceContainer
    {
        public WorkspaceContainer(Workspace data)
        {
            Workspace = data;
        }

        public Workspace Workspace { get; }
    }
}
