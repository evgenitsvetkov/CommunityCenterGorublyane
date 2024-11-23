using CommunityCenterGorublyane.Infrastructure.Data.Models;
using CommunityCenterGorublyane.Infrastructure.Data.SeedData.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CommunityCenterGorublyane.Infrastructure.Data
{
    public class CommunityCenterDbContext : IdentityDbContext
    {
        private bool _seedDb;

        public CommunityCenterDbContext(DbContextOptions<CommunityCenterDbContext> options, bool seed = true)
            : base(options)
        {
            if (Database.IsRelational())
            {
                Database.Migrate();
            } 
            else
            {
                Database.EnsureDeleted();
                Database.EnsureCreated();
            }
            _seedDb = seed;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            if (_seedDb)
            {
                builder.ApplyConfiguration(new UserConfiguration());
                builder.ApplyConfiguration(new CommentConfiguration());
                builder.ApplyConfiguration(new ActivityConfiguration());
            }

            base.OnModelCreating(builder);
        }

        public DbSet<Activity> Activities { get; set; } = null!;

        public DbSet<News> News { get; set; } = null!;

        public DbSet<Comment> Comments { get; set; } = null!;
    }
}
