using Dataframework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dataframework.EntityConfiguration
{
    public class ProjectConfiguration
    {
        public ProjectConfiguration(EntityTypeBuilder<Project> entity)
        {
            entity.ToTable("Project");
            entity.HasKey(u => u.Id);
            entity.Property(u => u.Name).HasMaxLength(30).IsRequired();
        }
    }
}