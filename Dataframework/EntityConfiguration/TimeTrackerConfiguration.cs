using Dataframework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dataframework.EntityConfiguration
{
    public class TimeTrackerConfiguration
    {
        public TimeTrackerConfiguration(EntityTypeBuilder<TimeTracker> entity)
        {
            entity.ToTable("TimeTracker");
            entity.HasKey(u => u.Id);
            entity.Property(u => u.Time).IsRequired();
            entity.Property(u => u.Notes).HasMaxLength(300);
        }
    }
}