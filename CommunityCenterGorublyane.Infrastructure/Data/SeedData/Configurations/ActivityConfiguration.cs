using CommunityCenterGorublyane.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CommunityCenterGorublyane.Infrastructure.Data.SeedData.Configurations
{
    internal class ActivityConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            var data = new SeedData();

            builder.HasData(new Activity[] { data.FirstActivity, data.SecondActivity, data.ThirdActivity, data.FourthActivity, data.FifthActivity, data.SixthActivity });
        }
    }
}
