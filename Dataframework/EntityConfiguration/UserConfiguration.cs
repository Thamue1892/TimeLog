using Dataframework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dataframework.EntityConfiguration
{
    public class UserConfiguration
    {
        public UserConfiguration(EntityTypeBuilder<User> entity)
        {
            entity.ToTable("User");
            entity.HasKey(u => u.Id);
            entity.Property(u => u.FullName).HasMaxLength(60).IsRequired();
            entity.Property(u => u.Email).HasMaxLength(120).IsRequired();
            entity.Property(u => u.Address).HasMaxLength(120);
            entity.Property(u => u.RoleId).IsRequired();
            entity.Property(u => u.SupervisorId).IsRequired();
            entity.Property(u => u.IsActive).IsRequired();
        }
    }
}