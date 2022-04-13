using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dataframework.Entities;

namespace TimeLog.API.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }

        // public IList<UserInProject> UserInProject { get; set; }
        // public IList<TimeInProject> TimeInProject { get; set; }
    }
}
