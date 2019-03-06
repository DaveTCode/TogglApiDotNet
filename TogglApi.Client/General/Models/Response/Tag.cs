using System;

namespace TogglApi.Client.General.Models.Response
{
    public class Tag
    {
        public long TagId { get; }

        public long WorkspaceId { get; }
        
        public string Name { get; }
        
        public DateTime At { get; }

        public Tag(long id, long wid, string name, DateTime at)
        {
            TagId = id;
            WorkspaceId = wid;
            Name = name;
            At = at;
        }
    }
}
