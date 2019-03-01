using System;

namespace TogglApi.Client.General.Models.Response
{
    public class Group
    {
        public long GroupId { get; }

        public long WorkspaceId { get; }

        public string Name { get; }

        public DateTime At { get; }

        public Group(long id, long wid, string name, DateTime at)
        {
            GroupId = id;
            WorkspaceId = wid;
            Name = name;
            At = at;
        }
    }
}
