using System;

namespace TogglApi.Client.General.Models.Response
{
    public class Task
    {
        public long TaskId { get; }

        public long WorkspaceId { get; }

        public string Name { get; }

        public long ProjectId { get; }

        public long UserId { get; }

        public bool Active { get; }

        public DateTime At { get; }

        public long EstimatedSeconds { get; }

        public Task(long id, long wid, string name, long pid, long uid, bool active, DateTime at, long estimatedSeconds)
        {
            TaskId = id;
            WorkspaceId = wid;
            Name = name;
            ProjectId = pid;
            UserId = uid;
            Active = active;
            At = at;
            EstimatedSeconds = estimatedSeconds;
        }
    }
}
