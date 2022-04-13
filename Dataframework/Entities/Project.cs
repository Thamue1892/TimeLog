using System.Collections.Generic;

namespace Dataframework.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<UserInProject> UserInProject { get; set; }
        public IList<TimeInProject> TimeInProject { get; set; }
    }
}