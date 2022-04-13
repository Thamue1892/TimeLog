namespace Dataframework.Entities
{
    public class TimeInProject
    {
        public int TimeTrackerId { get; set; }
        public TimeTracker TimeTracker { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}