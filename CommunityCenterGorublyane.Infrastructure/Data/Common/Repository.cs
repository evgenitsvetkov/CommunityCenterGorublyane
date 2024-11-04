using Microsoft.EntityFrameworkCore;

namespace CommunityCenterGorublyane.Infrastructure.Data.Common
{
    public class Repository : IRepository
    {
        private readonly DbContext context;

        public Repository(CommunityCenterDbContext _context)
        {
            context = _context;
        }

        private DbSet<T> Dbset<T>() where T : class
        {
            return context.Set<T>();
        }

        public IQueryable<T> All<T>() where T : class
        {
            return Dbset<T>();
        }

        public IQueryable<T> AllReadOnly<T>() where T : class
        {
            return Dbset<T>().AsNoTracking();   
        }

        public async Task AddAsync<T>(T entity) where T : class
        {
            await Dbset<T>().AddAsync(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }

        public async Task<T?> GetByIdAsync<T>(object id) where T : class
        {
            return await Dbset<T>().FindAsync(id);
        }
    }
}
