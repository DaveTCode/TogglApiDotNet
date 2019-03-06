using System;
using System.Collections.Generic;
using System.Text;

namespace TogglApi.Client.General.Models.Response
{
    public class User
    {
        public long UserId { get; }

        public long DefaultWorkspaceId { get; }

        public string Email { get; }

        public string Fullname { get; }

        public string JqueryTimeofdayFormat { get; }

        public string JqueryDateFormat { get; }

        public string TimeofdayFormat { get; }

        public string DateFormat { get; }

        public bool StoreStartAndStopTime { get; }

        public long BeginningOfWeek { get; }

        public string Language { get; }

        public Uri ImageUrl { get; }

        public bool SidebarPiechart { get; }

        public DateTimeOffset At { get; }

        public long Retention { get; }

        public bool RecordTimeline { get; }

        public bool RenderTimeline { get; }

        public bool TimelineEnabled { get; }

        public bool TimelineExperiment { get; }

        public dynamic NewBlogPost { get; }

        public bool ShouldUpgrade { get; }

        public dynamic Invitation { get; }

        public User(long id, long defaultWid, string email, string fullname, string jqueryDateFormat, string jqueryTimeofdayFormat, string timeofdayFormat, string dateFormat, bool storeStartAndStopTime, long beginningOfWeek, string language, Uri imageUrl, bool sidebarPiechart, DateTimeOffset at, long retention, bool recordTimeline, bool renderTimeline, bool timelineEnabled, bool timelineExperiment, dynamic newBlogPost, bool shouldUpgrade, dynamic invitation)
        {
            UserId = id;
            DefaultWorkspaceId = defaultWid;
            Email = email;
            Fullname = fullname;
            JqueryDateFormat = jqueryDateFormat;
            JqueryTimeofdayFormat = jqueryTimeofdayFormat;
            TimeofdayFormat = timeofdayFormat;
            DateFormat = dateFormat;
            StoreStartAndStopTime = storeStartAndStopTime;
            BeginningOfWeek = beginningOfWeek;
            Language = language;
            ImageUrl = imageUrl;
            SidebarPiechart = sidebarPiechart;
            At = at;
            Retention = retention;
            RecordTimeline = recordTimeline;
            RenderTimeline = renderTimeline;
            TimelineEnabled = timelineEnabled;
            TimelineExperiment = timelineExperiment;
            NewBlogPost = newBlogPost;
            ShouldUpgrade = shouldUpgrade;
            Invitation = invitation;
        }
    }
}
