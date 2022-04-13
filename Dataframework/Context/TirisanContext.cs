using Dataframework.Entities;
using Dataframework.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Dataframework.Context
{
    public class TirisanContext : DbContext
    {
        public readonly string connectionString;
        public TirisanContext()
        {
            connectionString = "Data Source=.\\sqlexpress; Initial Catalog=TimeLog; Integrated Security=True;";
        }

        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<UserInProject> UserInProject { get; set; }
        public DbSet<TimeTracker> TimeTracker { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("dbo");
            new UserConfiguration(modelBuilder.Entity<User>());
            new RoleConfiguration(modelBuilder.Entity<Role>());
            modelBuilder.Entity<Role>()
                .HasIndex(b => b.Name);

            new TimeTrackerConfiguration(modelBuilder.Entity<TimeTracker>());

            new ProjectConfiguration(modelBuilder.Entity<Project>());
            new UserInProjectConfiguration(modelBuilder.Entity<UserInProject>());
            new TimeInProjectConfiguration(modelBuilder.Entity<TimeInProject>());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}