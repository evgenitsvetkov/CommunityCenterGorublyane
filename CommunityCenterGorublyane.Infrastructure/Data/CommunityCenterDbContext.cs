using CommunityCenterGorublyane.Infrastructure.Data.Models;
using CommunityCenterGorublyane.Infrastructure.Data.SeedData.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CommunityCenterGorublyane.Infrastructure.Data
{
    public class CommunityCenterDbContext : IdentityDbContext
    {
        public CommunityCenterDbContext(DbContextOptions<CommunityCenterDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new CommentConfiguration());
            builder.ApplyConfiguration(new ActivityConfiguration());

            base.OnModelCreating(builder);
        }

        public DbSet<Activity> Activities { get; set; } = null!;

        public DbSet<News> News { get; set; } = null!;

        public DbSet<Comment> Comments { get; set; } = null!;
    }
}
