using CarAppDotNetApi.Data;
using Microsoft.EntityFrameworkCore;

namespace CarAppDotNetApi.Repositories.BaseRepositories
{
    public abstract class BaseRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        protected void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}