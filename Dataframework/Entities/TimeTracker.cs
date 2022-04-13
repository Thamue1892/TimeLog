using System.Collections.Generic;

namespace Dataframework.Entities
{
    public class TimeTracker
    {
        public int Id { get; set; }
        public double Time { get; set; }
        public string Notes { get; set; }
        public IList<TimeInProject> TimeInProject { get; set; }
    }
}