using Dataframework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dataframework.EntityConfiguration
{
    public class UserInProjectConfiguration
    {
        public UserInProjectConfiguration(EntityTypeBuilder<UserInProject> entity)
        {
            entity.ToTable("UserInProject");
            entity.HasKey(up => new { up.UserId, up.ProjectId });
            // entity.HasOne(u => u.User).WithMany(p => p.UserInProject)
            //     .HasForeignKey(x => x.ProjectId);

        }
    }
}