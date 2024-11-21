using CommunityCenterGorublyane.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CommunityCenterGorublyane.Tests.Mocks
{
    public static class DatabaseMock
    {
        public static CommunityCenterDbContext Instance
        {
            get
            {
                var dbContextOptions = new DbContextOptionsBuilder<CommunityCenterDbContext>()
                    .UseInMemoryDatabase("CommunityCenterInMemoryDb" + DateTime.Now.Ticks.ToString()).Options;

                return new CommunityCenterDbContext(dbContextOptions, false);
            }
        }
    }
}
