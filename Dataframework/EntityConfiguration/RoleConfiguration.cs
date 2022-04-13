using Dataframework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dataframework.EntityConfiguration
{
    public class RoleConfiguration
    {
        public RoleConfiguration(EntityTypeBuilder<Role> entity)
        {
            entity.ToTable("Role");
            entity.HasKey(u => u.Id);
            entity.Property(u => u.Name).HasMaxLength(30).IsRequired();
        }
    }
}