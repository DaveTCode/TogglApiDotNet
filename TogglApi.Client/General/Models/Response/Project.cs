using System;

namespace TogglApi.Client.General.Models.Response
{
    public class Project
    {
        public long ProjectId { get; }

        public long WorkspaceId { get; }

        //TODO - what is this?
        public long CId { get; }

        public string Name { get; }

        public bool Billable { get; }

        public bool IsPrivate { get; }

        public bool Active { get; }

        public DateTime CreatedAt { get; }

        // TODO - What is this?
        public DateTime At { get; }

        public string Color { get; }

        public bool AutoEstimates { get; }

        public long ActualHours { get; }

        public string HexColor { get; }

        public Project(long id, long wid, long cId, string name, bool billable, bool isPrivate,
            bool active, DateTime createdAt, DateTime at, string color, bool autoEstimates, long actualHours,
            string hexColor)
        {
            ProjectId = id;
            WorkspaceId = wid;
            CId = cId;
            Name = name;
            Billable = billable;
            IsPrivate = isPrivate;
            Active = active;
            CreatedAt = createdAt;
            At = at;
            Color = color;
            AutoEstimates = autoEstimates;
            ActualHours = actualHours;
            HexColor = hexColor;
        }
    }
}
