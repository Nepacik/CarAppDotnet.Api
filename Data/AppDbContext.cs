using CarAppDotNetApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CarAppDotNetApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Model> Models { get; set; }
        
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
            
        }
    }
}