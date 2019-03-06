using System;
using System.Collections.Generic;
using System.Text;

namespace TogglApi.Client.General.Models.Response
{
    public class Client
    {
        public long ClientId { get; }
        
        public long WorkspaceId { get; }
        
        public string Name { get; }
        
        public DateTime At { get; }

        public Client(long id, long wid, string name, DateTime at)
        {
            ClientId = id;
            WorkspaceId = wid;
            Name = name;
            At = at;
        }
    }
}
