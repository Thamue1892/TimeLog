using Dataframework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dataframework.EntityConfiguration
{
    public class TimeInProjectConfiguration
    {
        public TimeInProjectConfiguration(EntityTypeBuilder<TimeInProject> entity)
        {
            entity.ToTable("TimeInProject");
            entity.HasKey(t => new { t.TimeTrackerId, t.ProjectId });
            entity.HasOne(u => u.TimeTracker).WithMany(p => p.TimeInProject);

        }
    }
}